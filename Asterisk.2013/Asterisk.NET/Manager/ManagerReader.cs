using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using AsterNET.IO;
using AsterNET.Manager.Action;
using AsterNET.Manager.Event;
using AsterNET.Manager.Response;
using System.Threading.Tasks;

namespace AsterNET.Manager
{
	/// <summary>
	///     Default implementation of the ManagerReader interface.
	/// </summary>
	public class ManagerReader
	{
        private Thread ReaderThread;
        private Thread MountThread;
        private Task ReaderTask;
        private Task MountTask;

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

        string lineBuffer = string.Empty;
        public void BeginReading()
        {
            if (!mrConnector.forcedStop)
            {
                if (mrSocket.IsConnected)
                {
                    mrConnector.EnsureSocketConnection(true, null);
                    mrConnector.EnsureConnectionState(ManagerConnectionStatus.READING, null);
                    
                    string lineBuffer = string.Empty;
                    byte[] buffer = new byte[mrSocket.TcpClient.ReceiveBufferSize];

                    mrSocket.NetworkStream.BeginRead(
                        buffer, 0, buffer.Length,
                        new AsyncCallback(EndReading),
                        buffer);
                }
            }
        }

        public void EndReading(IAsyncResult ar)
        {
            int numberOfBytesRead = mrSocket.NetworkStream.EndRead(ar);
            if (numberOfBytesRead != 0)
            {
                ReadProccess(numberOfBytesRead, ((byte[])ar.AsyncState), lineBuffer);
            }            
            BeginReading();
            if (lineQueue.Count > 0) BeginMounting();
        }

        private void ReadProccess(int count, byte[] buffer, string lineBuffer)
        {
            mrConnector.EnsureConnectionState(ManagerConnectionStatus.READY, null);
            try
            {
                TotalReceivedBytes += count;
                mrConnector.lastPacketTime = DateTime.Now;
                string line = mrSocket.Encoding.GetString(buffer, 0, count);
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

                Contador["Leitura"]++;
            }
            catch (Exception ex) { mrConnector.fireEvent(new ErrorEvent(mrConnector, ex)); }
        }

        private void ReaderWork()
        {
            byte[] lineBytes = new byte[mrSocket.TcpClient.ReceiveBufferSize];
            string lineBuffer = string.Empty;
            while (true)
            {
                if (!mrConnector.forcedStop)
                {
                    if (mrSocket.IsConnected)
                    {
                        mrConnector.EnsureConnectionState(ManagerConnectionStatus.READING, null);
                        mrConnector.EnsureSocketConnection(true, null);
                        int count = 0;
                        Exception exRead = null;
                        try
                        {
                            count = mrSocket.NetworkStream.Read(lineBytes, 0, lineBytes.Length);
                        }
                        catch (Exception ex)
                        {
                            exRead = ex;
                            mrConnector.fireEvent(new ErrorEvent(mrConnector, ex));
                        }

                        if (count == 0 && exRead == null) { mrConnector.setDisconnected("Broken"); }
                        else
                        {
                            ReadProccess(count, lineBytes, lineBuffer);
                        }
                    }
                    else { mrConnector.EnsureSocketConnection(false, new Exception("fail on check connected")); }
                }
            }
        }

        #endregion
        #region MOUNTING

        bool mounting = false;
        bool processingCommandResult = false;
        DDictionary<string, string> packet = new DDictionary<string, string>();
        private void BeginMounting()
        {            
            if (!mrConnector.forcedStop)
            {                
                try
                {
                    while (lineQueue.Count > 0 && !mounting)
                    {                        
                        mounting = true;
                        MountProccess(packet, processingCommandResult);
                        mounting = false;
                    }
                }
                catch (Exception ex)
                {
                    mrConnector.fireEvent(new ErrorEvent(mrConnector, ex));
                }
            }
        }
                
        private void MountWork()
        {            
            while (true)
            {
                if (!mrConnector.forcedStop)
                {
                    try
                    {
                        if (lineQueue.Count > 0)
                        {
                            MountProccess(packet, processingCommandResult);
                        }
                    }
                    catch (Exception ex)
                    {
                        mrConnector.fireEvent(new ErrorEvent(mrConnector, ex));
                    }
                }
            }
        }

        
        private void MountProccess(IDictionary<string, string> packet, bool processingCommandResult)
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
                    lock (packet) packet.Clear();
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

                return;
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
                    return;
                }
                if (line.Trim().ToLower(Helper.CultureInfo) == "response: follows")
                {
                    // Switch to wait "--END COMMAND--" mode
                    processingCommandResult = true;
                    lock (packet) packet.Clear();
                    commandList.Clear();
                    Helper.AddKeyValue(packet, line);
                    return;
                }
                Helper.AddKeyValue(packet, line);
                return;
            }

            #endregion

            #region process events and responses

            if (packet.ContainsKey("event"))
                mrConnector.DispatchEvent(packet);
            else if (packet.ContainsKey("response"))
                mrConnector.DispatchResponse(packet);

            #endregion

            lock(packet) packet.Clear();
        }

        #endregion
        #region Reinitialize 

        internal void Reinitialize()
		{
            mrSocket.Initial = false;
            lineQueue.Clear();
			commandList.Clear();			
		    mrConnector.lastPacketTime = DateTime.Now;
			wait4identiier = true;
            processingCommandResult = false;            
        }

        #endregion

        #region Run() / Stop()

        internal void Stop()
        {
            if (ReaderThread != null && ReaderThread.IsAlive)            
                ReaderThread.Abort();
            
            if (MountThread != null && MountThread.IsAlive)
                MountThread.Abort();            
        }

        /// <summary>
        /// Reads line by line from the asterisk server, sets the protocol identifier as soon as it is
        /// received and dispatches the received events and responses via the associated dispatcher.
        /// </summary>
        /// <seealso cref="ManagerConnection.DispatchEvent(ManagerEvent)" />
        /// <seealso cref="ManagerConnection.DispatchResponse(Response.ManagerResponse)" />
        /// <seealso cref="ManagerConnection.setProtocolIdentifier(String)" />
        internal void Run()
		{
            
            if (true)
            {
                BeginReading();
                //if (ReaderTask == null || ReaderTask.Status != TaskStatus.Running)
                //{
                //    ReaderTask = new Task(ReaderWork);
                //    ReaderTask.Start();
                //}

                //if (MountTask == null || MountTask.Status != TaskStatus.Running)
                //{
                //    MountTask = new Task(MountWork);
                //    MountTask.Start();
                //}
            }
            else
            {
                if (ReaderThread == null || ReaderThread.IsAlive)
                {
                    ReaderThread = new Thread(ReaderWork) { IsBackground = true };
                    ReaderThread.Name = "ManagerReader Enqueue-" + DateTime.Now.Second;
                    ReaderThread.Start();
                }

                if (MountThread == null || !MountThread.IsAlive)
                {
                    MountThread = new Thread(MountWork) { IsBackground = true };
                    MountThread.Name = "ManagerReader Mount-" + DateTime.Now.Second;
                    MountThread.Start();
                }
            }      
		}

		#endregion
	}
}
