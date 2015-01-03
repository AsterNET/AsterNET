using System.IO;
using AsterNET.FastAGI.Command;
using AsterNET.IO;

namespace AsterNET.FastAGI
{
    /// <summary>
    ///     Default implementation of the AGIWriter interface.
    /// </summary>
    public class AGIWriter
    {
        private readonly SocketConnection socket;

        public AGIWriter(SocketConnection socket)
        {
            lock (this)
                this.socket = socket;
        }

        public void SendCommand(AGICommand command)
        {
            string buffer = command.BuildCommand() + "\n";
            try
            {
                socket.Write(buffer);
            }
            catch (IOException e)
            {
                throw new AGINetworkException("Unable to send command to Asterisk: " + e.Message, e);
            }
        }
    }
}