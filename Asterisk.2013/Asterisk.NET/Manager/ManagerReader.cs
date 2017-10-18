using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using AsterNET.IO;
using AsterNET.Manager.Action;
using AsterNET.Manager.Event;
using AsterNET.Manager.Response;

namespace AsterNET.Manager
{
	/// <summary>
	///     Default implementation of the ManagerReader interface.
	/// </summary>
	public class ManagerReader
	{
        private Thread ReaderWork;
        private Thread MountWork;

#if LOGGER
		private readonly Logger logger = Logger.Instance();
#endif

        private readonly ManagerConnection mrConnector;
		private SocketConnection mrSocket;

        private bool die = false;
		private bool is_logoff;
        
        public IDictionary<string, int> Contador { get; } = new DDictionary<string, int>();
        public int Queued { get { return lineQueue.Count; } }
        public long TotalReceivedBytes;

		public readonly Queue<string> lineQueue = new Queue<string>();
        
		
		private bool wait4identiier;
		
		
		private readonly List<string> commandList = new List<string>();

        #region ManagerReader(dispatcher, asteriskServer) 

        /// <summary>
        ///     Creates a new ManagerReader.
        /// </summary>
        /// <param name="dispatcher">the dispatcher to use for dispatching events and responses.</param>
        public ManagerReader(ManagerConnection connection)
		{   
            mrConnector = connection;
            mrConnector.SocketStatusChanged += MrConnector_SocketStatusChanged;
            ReaderWork = new Thread(ReadTask) { IsBackground = false };
            MountWork = new Thread(MountTask) { IsBackground = false };
        }

        private void MrConnector_SocketStatusChanged(object sender, SocketStatusChangedEventArgs e)
        {
            if (e.Status)
            {
                Reinitialize();
            }
        }

        #endregion

        #region Socket 

        /// <summary>
        ///     Sets the socket to use for reading from the asterisk server.
        /// </summary>
        internal SocketConnection Socket
		{
			set { mrSocket = value; }
		}

		#endregion
        
		#region IsLogoff 

		internal bool IsLogoff
		{
			set { is_logoff = value; }
		}

        #endregion

        #region mrReaderCallbback(IAsyncResult ar) 

        /*
        /// <summary>
        /// Async Read callback
        /// </summary>
        /// <param name="ar">IAsyncResult</param>
        private void mrReaderCallbback(IAsyncResult ar)
        {
            // mreader = Mr.Reader
            var mrReader = (ManagerReader)ar.AsyncState;
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
                    if (!is_logoff)
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
                        mrReader.lineBuffer = (idx + 1 < mrReader.lineBuffer.Length
                            ? mrReader.lineBuffer.Substring(idx + 1)
                            : string.Empty);
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
        */
        #endregion
        #region INCOMING

        private void ReadTask()
        {
            byte[] lineBytes = new byte[mrSocket.TcpClient.ReceiveBufferSize];
            string lineBuffer = string.Empty;

            while (true)
            {
                bool wait = true;

                if (die) { mrConnector.setDisconnected("Die"); }
                else
                {
                    if (mrSocket.IsConnected)
                    {
                        mrConnector.EnsureSocketConnection(true, null);
                        int count = 0;
                        Exception exRead = null;
                        try
                        {
                            count = mrSocket.NetworkStream.Read(lineBytes, 0, lineBytes.Length);
                            mrConnector.EnsureConnectionState(ManagerConnectionStatus.READY, null);
                        }
                        catch (Exception ex)
                        {
                            exRead = ex;
                            mrConnector.fireEvent(new ErrorEvent(mrConnector, ex));
                        }

                        if (count == 0 && exRead == null) { mrConnector.setDisconnected("Broken"); }
                        else
                        {
                            try
                            {
                                TotalReceivedBytes += count;
                                mrConnector.lastPacketTime = DateTime.Now;
                                Contador["Espera"] = 0;
                                string line = mrSocket.Encoding.GetString(lineBytes, 0, count);
                                lineBuffer += line;
                                int idx;
                                // \n - because not all dev in Digium use \r\n
                                // .Trim() kill \r
                                lock (((ICollection)lineQueue).SyncRoot)
                                    while (!string.IsNullOrEmpty(lineBuffer) && (idx = lineBuffer.IndexOf("\n")) >= 0)
                                    {
                                        line = idx > 0 ? lineBuffer.Substring(0, idx).Trim() : string.Empty;
                                        lineBuffer = (idx + 1 < lineBuffer.Length
                                            ? lineBuffer.Substring(idx + 1)
                                            : string.Empty);
                                        lineQueue.Enqueue(line);
                                    }

                                wait = false;
                                Contador["Leitura"]++;
                            }
                            catch (Exception ex)
                            {
                                mrConnector.fireEvent(new ErrorEvent(mrConnector, ex));
                            }
                        }
                    }
                    else { mrConnector.EnsureSocketConnection(false, new Exception("fail on check connected")); }
                }

                if (wait) { Contador["Espera"]++; Thread.SpinWait(500); }
            }
        }

        bool processingCommandResult = false;
        private void MountTask()
        {            
            DDictionary<string, string> packet = new DDictionary<string, string>();
            bool wait = false;
            while (true)
            {
                try
                {
                    if (lineQueue.Count == 0)
                    {
                        wait = true;
                    }
                    else
                    {
                        string line;
                        
                        lock (((ICollection)lineQueue).SyncRoot)
                            line = lineQueue.Dequeue().Trim();

                        #region processing Response: Follows

                        if (processingCommandResult)
                        {
                            string lineLower = line.ToLower(Helper.CultureInfo);
                            if (lineLower == "--end command--")
                            {
                                var commandResponse = new CommandResponse();
                                Helper.SetAttributes(commandResponse, packet);
                                commandList.Add(line);
                                commandResponse.Result = commandList;
                                processingCommandResult = false;
                                packet.Clear();
                                mrConnector.DispatchResponse(commandResponse);
                            }
                            else if (lineLower.StartsWith("privilege: ")
                                || lineLower.StartsWith("actionid: ")
                                || lineLower.StartsWith("timestamp: ")
                                || lineLower.StartsWith("server: ")
                                )
                                Helper.AddKeyValue(packet, line);
                            else
                                commandList.Add(line);

                            continue;
                        }

                        #endregion

                        #region collect key: value and ProtocolIdentifier

                        if (!string.IsNullOrEmpty(line))
                        {
                            if (wait4identiier && line.StartsWith("Asterisk Call Manager"))
                            {
                                wait4identiier = false;
                                var connectEvent = new ConnectEvent(mrConnector);
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
                }
                catch (Exception ex)
                {
                    mrConnector.fireEvent(new ErrorEvent(mrConnector, ex));
                    wait = true;
                }
                if (wait) { Thread.SpinWait(500); }
            }
        }

        #endregion
        #region Reinitialize 

        internal void Reinitialize()
		{
            mrSocket.Initial = false;
            mrConnector.disconnected = false;
            lineQueue.Clear();
			commandList.Clear();			
		    mrConnector.lastPacketTime = DateTime.Now;
			wait4identiier = true;
            processingCommandResult = false;            
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
		internal void Run()
		{
            if (mrSocket == null)
            {
                mrConnector.DispatchEvent(new ErrorEvent(mrConnector, new Exception("unable to run: socket is null")));
                return;
            }

            if (ReaderWork.ThreadState != (ThreadState.Running | ThreadState.WaitSleepJoin))
            {
                ReaderWork.Name = "ManagerReader Enqueue-" + DateTime.Now.Second;
                ReaderWork.Start();
            }

            if (MountWork.ThreadState != (ThreadState.Running | ThreadState.WaitSleepJoin))
            {
                MountWork.Name = "ManagerReader Mount-" + DateTime.Now.Second;
                MountWork.Start();
            }
            
			while (true)
			{
				try
				{
					while (!die)
					{
						if (!is_logoff)
						{
                            if (mrSocket == null)                            
                                mrConnector.setDisconnected("socket is null");
                            
                            if (mrConnector.disconnected)                            
                                mrConnector.setDisconnected("sei lá");                            
						}                    
                    }
					break;
				}
				catch(Exception ex)
				{
                    mrConnector.fireEvent(new ErrorEvent(mrConnector, ex));
                }

                if (die)
					break;

				mrConnector.DispatchEvent(new DisconnectEvent(mrConnector, "unknow error"));
			}
		}

		#endregion
	}
}
