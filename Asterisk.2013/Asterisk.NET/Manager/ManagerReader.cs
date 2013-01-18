using System;
using System.IO;
using System.Collections;
using System.Threading;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using Asterisk.NET.IO;
using Asterisk.NET.Manager.Event;
using Asterisk.NET.Manager.Response;

namespace Asterisk.NET.Manager
{
	
	/// <summary>
	/// Default implementation of the ManagerReader interface.
	/// </summary>
	public class ManagerReader
	{
#if LOGGER
		private Logger logger = Logger.Instance();
#endif

		private ManagerConnection mrConnector;
		private SocketConnection mrSocket;

		private bool die = false;
		private bool is_logoff = false;
		private bool disconnect = false;
		private byte[] lineBytes;
		private string lineBuffer;
		private Queue<string> lineQueue;
		private ResponseHandler pingHandler;
		private bool processingCommandResult;
		private bool wait4identiier;
		private DateTime lastPacketTime;
		Dictionary<string, string> packet;
		List<string> commandList;

		#region ManagerReader(dispatcher, asteriskServer) 
		/// <summary>
		/// Creates a new ManagerReader.
		/// </summary>
		/// <param name="dispatcher">the dispatcher to use for dispatching events and responses.</param>
		public ManagerReader(ManagerConnection connection)
		{
			this.mrConnector = connection;
			this.die = false;
			lineQueue = new Queue<string>();
			packet = new Dictionary<string, string>();
			commandList = new List<string>();
		}
		#endregion

		#region Socket 
		/// <summary>
		/// Sets the socket to use for reading from the asterisk server.
		/// </summary>
		internal IO.SocketConnection Socket
		{
			set
			{
				this.mrSocket = value;
			}
		}
		#endregion

		#region Die 
		internal bool Die
		{
			get { return die; }
			set
			{
				die = value;
				if (die)
					this.mrSocket = null;
			}
		}
		#endregion

		#region IsLogoff 
		internal bool IsLogoff
		{
			set { is_logoff = value; }
		}
		#endregion

		#region mrReaderCallbback(IAsyncResult ar) 
		/// <summary>
		/// Async Read callback
		/// </summary>
		/// <param name="ar">IAsyncResult</param>
		private void mrReaderCallbback(IAsyncResult ar)
		{
			// mreader = Mr.Reader
			ManagerReader mrReader = (ManagerReader)ar.AsyncState;
			if (mrReader.die)
				return;

			SocketConnection mrSocket = mrReader.mrSocket;
			if (mrSocket == null || mrSocket.TcpClient == null)
			{
				// No socket - it's DISCONNECT !!!
				disconnect = true;
				return;
			}

			NetworkStream nstream = mrSocket.NetworkStream;
			if (nstream == null)
			{
				// No network stream - it's DISCONNECT !!!
				disconnect = true;
				return;
			}

			try
			{
				int count = nstream.EndRead(ar);
				if (count == 0)
				{
					// No received data - it's may be DISCONNECT !!!
					if(!is_logoff)
						disconnect = true;
					return;
				}
				string line = mrSocket.Encoding.GetString(mrReader.lineBytes, 0, count);
				mrReader.lineBuffer += line;
				int idx;
				// \n - because not all dev in Digium use \r\n
				// .Trim() kill \r
				lock (((ICollection)lineQueue).SyncRoot)
					while (!string.IsNullOrEmpty(mrReader.lineBuffer) && (idx = mrReader.lineBuffer.IndexOf("\n")) >= 0)
					{
						line = idx > 0 ? mrReader.lineBuffer.Substring(0, idx).Trim() : string.Empty;
						mrReader.lineBuffer = (idx + 1 < mrReader.lineBuffer.Length ? mrReader.lineBuffer.Substring(idx + 1) : string.Empty);
						lineQueue.Enqueue(line);
					}
				// Give a next portion !!!
				nstream.BeginRead(mrReader.lineBytes, 0, mrReader.lineBytes.Length, mrReaderCallbback, mrReader);
			}
#if LOGGER
			catch (Exception ex)
			{
				mrReader.logger.Error("Read data error", ex.Message);
#else
			catch
			{
#endif
				// Any catch - disconncatch !
				disconnect = true;
				if (mrReader.mrSocket != null)
					mrReader.mrSocket.Close();
				mrReader.mrSocket = null;
			}
		}
		#endregion

		#region Reinitialize 
		internal void Reinitialize()
		{
			mrSocket.Initial = false;
			disconnect = false;
			lineQueue.Clear();
			packet.Clear();
			commandList.Clear();
			lineBuffer = string.Empty;
			lineBytes = new byte[mrSocket.TcpClient.ReceiveBufferSize];
			lastPacketTime = DateTime.Now;
			wait4identiier = true;
			processingCommandResult = false;
			mrSocket.NetworkStream.BeginRead(lineBytes, 0, lineBytes.Length, mrReaderCallbback, this);
			lastPacketTime = DateTime.Now;
		}
		#endregion

		#region Run()
		/// <summary>
		/// Reads line by line from the asterisk server, sets the protocol identifier as soon as it is
		/// received and dispatches the received events and responses via the associated dispatcher.
		/// </summary>
		/// <seealso cref="ManagerConnection.DispatchEvent(ManagerEvent)" />
		/// <seealso cref="ManagerConnection.DispatchResponse(Response.ManagerResponse)" />
		/// <seealso cref="ManagerConnection.setProtocolIdentifier(String)" />
		internal void  Run()
		{
			if (mrSocket == null)
				throw new SystemException("Unable to run: socket is null.");

			string line;

			while (true)
			{
				try
				{
					while (!die)
					{
						#region check line from *
						if (!is_logoff)
						{
							if (mrSocket != null && mrSocket.Initial)
							{
								Reinitialize();
							}
							else if (disconnect)
							{
								disconnect = false;
								mrConnector.DispatchEvent(new DisconnectEvent(mrConnector));
							}
						}
						if (lineQueue.Count == 0)
						{
							if (mrConnector.PingInterval > 0
								&& mrSocket != null
								&& !wait4identiier
								&& !is_logoff
								&& lastPacketTime.AddMilliseconds(mrConnector.PingInterval) < DateTime.Now
								)
							{
								if (pingHandler != null)
								{
									// In 1.6.0 no Response from Ping
									if (pingHandler.Response == null)
									{
										// If one PingInterval from Ping without Pong then send Disconnect event
										mrConnector.DispatchEvent(new DisconnectEvent(mrConnector));
									}
									pingHandler.Free();
									mrConnector.RemoveResponseHandler(pingHandler);
									pingHandler = null;
								}
								else
								{
									// Send PING to *
									try
									{
										pingHandler = new ResponseHandler(new Action.PingAction(), null);
										mrConnector.SendAction(pingHandler.Action, pingHandler);
									}
									catch
									{
										disconnect = true;
										mrSocket = null;
									}
								}
								lastPacketTime = DateTime.Now;
							}
							Thread.Sleep(50);
							if (mrConnector.TraceCallerThread && mrConnector.CallerThread != null && mrConnector.CallerThread.ThreadState == ThreadState.Stopped)
							{
								die = true;
								break;
							}
							continue;
						}
						#endregion

						lastPacketTime = DateTime.Now;
						lock (((ICollection)lineQueue).SyncRoot)
							line = lineQueue.Dequeue().Trim();
#if LOGGER
						logger.Debug(line);
#endif
						#region processing Response: Follows
						if (processingCommandResult)
						{
							if (line == "--END COMMAND--")
							{
								Response.CommandResponse commandResponse = new Response.CommandResponse();
								Helper.SetAttributes(commandResponse, packet);
								commandResponse.Result = commandList;
								processingCommandResult = false;
								packet.Clear();
								mrConnector.DispatchResponse(commandResponse);
								continue;
							}
							else
							{
								string lineLower = line.ToLower(Helper.CultureInfo);
								if (lineLower.StartsWith("privilege: ")
									|| lineLower.StartsWith("actionid: ")
									|| lineLower.StartsWith("timestamp: ")
									|| lineLower.StartsWith("server: ")
									)
									Helper.AddKeyValue(packet, line);
								else
									commandList.Add(line);
							}
							continue;
						}
						#endregion

						#region collect key: value and ProtocolIdentifier
						if (!string.IsNullOrEmpty(line))
						{
							if (wait4identiier && line.StartsWith("Asterisk Call Manager"))
							{
								wait4identiier = false;
								ConnectEvent connectEvent = new ConnectEvent(mrConnector);
								connectEvent.ProtocolIdentifier = line;
								mrConnector.DispatchEvent(connectEvent);
								continue;
							}
							if (line.Trim().ToLower(Helper.CultureInfo) == "response: follows")
							{
								// Switch to wait "--END COMMAND--" mode
								processingCommandResult = true;
								packet.Clear();
								commandList.Clear();
								Helper.AddKeyValue(packet, line);
								continue;
							}
							Helper.AddKeyValue(packet, line);
							continue;
						}
						#endregion

						#region process events and responses

						if (packet.ContainsKey("event"))
							mrConnector.DispatchEvent(packet);

						else if (packet.ContainsKey("response"))
							mrConnector.DispatchResponse(packet);

						#endregion

						packet.Clear();
					}
					if(mrSocket != null)
						mrSocket.Close();
					break;
				}
#if LOGGER
				catch (Exception ex)
				{
					logger.Info("Exception : {0}", ex.Message);
#else
				catch
				{
#endif
				}

				if (die)
					break;

#if LOGGER
				logger.Info("No die, any error - send disconnect.");
#endif
				mrConnector.DispatchEvent(new DisconnectEvent(mrConnector));
			}
		}
		#endregion
	}
}
