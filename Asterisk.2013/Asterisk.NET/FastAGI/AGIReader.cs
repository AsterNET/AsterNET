using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Asterisk.NET.FastAGI
{
	public class AGIReader
	{
#if LOGGER
		private Logger logger = Logger.Instance();
#endif
		private IO.SocketConnection socket;
		public AGIReader(IO.SocketConnection socket)
		{
			this.socket = socket;
		}

		public AGIRequest ReadRequest()
		{
			string line;
			List<string> lines = new List<string>();
			try
			{
#if LOGGER
				logger.Info("AGIReader.ReadRequest():");
#endif
				while ((line = socket.ReadLine()) != null)
				{
					if (line.Length == 0)
						break;			
					lines.Add(line);
#if LOGGER
					logger.Info(line);
#endif
				}
			}
			catch (IOException ex)
			{
				throw new AGINetworkException("Unable to read request from Asterisk: " + ex.Message, ex);
			}

			AGIRequest request = new AGIRequest(lines);

			request.LocalAddress = socket.LocalAddress;
			request.LocalPort = socket.LocalPort;
			request.RemoteAddress = socket.RemoteAddress;
			request.RemotePort = socket.RemotePort;

			return request;
		}
		
		public AGIReply ReadReply()
		{
			string line;
			string badSyntax = ((int)AGIReplyStatuses.SC_INVALID_COMMAND_SYNTAX).ToString();

			List<string> lines = new List<string>();
			try
			{
				line = socket.ReadLine();
			}
			catch (IOException ex)
			{
				throw new AGINetworkException("Unable to read reply from Asterisk: " + ex.Message, ex);
			}
			if (line == null)
				throw new AGIHangupException();

			lines.Add(line);
			// read synopsis and usage if statuscode is 520
			if (line.StartsWith(badSyntax))
				try
				{
					while ((line = socket.ReadLine()) != null)
					{
						lines.Add(line);
						if (line.StartsWith(badSyntax))
							break;
					}
				}
				catch (IOException ex)
				{
					throw new AGINetworkException("Unable to read reply from Asterisk: " + ex.Message, ex);
				}
			return new AGIReply(lines);
		}
	}
}
