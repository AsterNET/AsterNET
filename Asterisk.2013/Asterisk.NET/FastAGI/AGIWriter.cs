using System;
using System.IO;
namespace Asterisk.NET.FastAGI
{
	/// <summary>
	/// Default implementation of the AGIWriter interface.
	/// </summary>
	public class AGIWriter
	{
		private IO.SocketConnection socket;

		public AGIWriter(IO.SocketConnection socket)
		{
			lock (this)
				this.socket = socket;
		}

		public void SendCommand(Command.AGICommand command)
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