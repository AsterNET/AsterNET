using System;
using System.IO;
using System.Threading;

namespace Asterisk.NET.FastAGI
{
	/// <summary>
	/// An AGIConnectionHandler is created and run by the AGIServer whenever a new
	/// socket connection from an Asterisk Server is received.<br/>
	/// It reads the request using an AGIReader and runs the AGIScript configured to
	/// handle this type of request. Finally it closes the socket connection.
	/// </summary>
	public class AGIConnectionHandler
	{
#if LOGGER
		private Logger logger = Logger.Instance();
#endif
		private static readonly LocalDataStoreSlot channel = Thread.AllocateDataSlot();
		private IO.SocketConnection socket;
		private MappingStrategy mappingStrategy;

		#region Channel
		/// <summary>
		/// Returns the AGIChannel associated with the current thread.
		/// </summary>
		/// <returns>the AGIChannel associated with the current thread or <code>null</code> if none is associated.</returns>
		internal static AGIChannel Channel
		{
			get
			{
				return (AGIChannel) Thread.GetData(AGIConnectionHandler.channel);
			}
		}
		#endregion

		#region AGIConnectionHandler(socket, mappingStrategy)
		/// <summary>
		/// Creates a new AGIConnectionHandler to handle the given socket connection.
		/// </summary>
		/// <param name="socket">the socket connection to handle.</param>
		/// <param name="mappingStrategy">the strategy to use to determine which script to run.</param>
		public AGIConnectionHandler(IO.SocketConnection socket, MappingStrategy mappingStrategy)
		{
			this.socket = socket;
			this.mappingStrategy = mappingStrategy;
		}
		#endregion

		public void Run()
		{
			try
			{
				AGIReader reader = new AGIReader(socket);
				AGIWriter writer = new AGIWriter(socket);
				AGIRequest request = reader.ReadRequest();
				AGIChannel channel = new AGIChannel(writer, reader);
				AGIScript script = mappingStrategy.DetermineScript(request);
				Thread.SetData(AGIConnectionHandler.channel, channel);

				if (script != null)
				{
#if LOGGER
					logger.Info("Begin AGIScript " + script.GetType().FullName + " on " + Thread.CurrentThread.Name);
#endif
					script.Service(request, channel);
#if LOGGER
					logger.Info("End AGIScript " + script.GetType().FullName + " on " + Thread.CurrentThread.Name);
#endif
				}
				else
				{
					string error;
					error = "No script configured for URL '" + request.RequestURL + "' (script '" + request.Script + "')";
					channel.SendCommand(new Command.VerboseCommand(error, 1));
#if LOGGER
					logger.Error(error);
#endif
				}
			}
			catch (AGIHangupException)
			{
			}
			catch (IOException)
			{
			}
			catch (AGIException ex)
			{
#if LOGGER
				logger.Error("AGIException while handling request", ex);
#else
				throw ex;
#endif
			}
			catch (Exception ex)
			{
#if LOGGER
				logger.Error("Unexpected Exception while handling request", ex);
#else
				throw ex;
#endif
			}

			Thread.SetData(AGIConnectionHandler.channel, null);
			try
			{
				socket.Close();
			}
#if LOGGER
			catch(IOException ex)
			{
				logger.Error("Error on close socket", ex);
			}
#else
			catch { }
#endif
		}
	}
}