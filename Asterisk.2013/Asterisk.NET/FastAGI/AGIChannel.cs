namespace Asterisk.NET.FastAGI
{
	/// <summary>
	/// Default implementation of the AGIChannel interface.
	/// </summary>
	public class AGIChannel
	{
		private AGIWriter agiWriter;
		private AGIReader agiReader;
		private AGIReply agiReply;

		public AGIChannel(IO.SocketConnection socket)
		{
			this.agiWriter = new AGIWriter(socket);
			this.agiReader = new AGIReader(socket);
		}

		public AGIChannel(AGIWriter agiWriter, AGIReader agiReader)
		{
			this.agiWriter = agiWriter;
			this.agiReader = agiReader;
		}

		/// <summary>
		/// Get last AGI Reply.
		/// </summary>
		public AGIReply LastReply
		{
			get { return agiReply; }
		}

		public AGIReply SendCommand(Command.AGICommand command)
		{
			agiWriter.SendCommand(command);
			agiReply = agiReader.ReadReply();
			int status = agiReply.GetStatus();
			if (status == (int)AGIReplyStatuses.SC_INVALID_OR_UNKNOWN_COMMAND)
				throw new InvalidOrUnknownCommandException(command.BuildCommand());
			else if (status == (int)AGIReplyStatuses.SC_INVALID_COMMAND_SYNTAX)
				throw new InvalidCommandSyntaxException(agiReply.GetSynopsis(), agiReply.GetUsage());
			return agiReply;
		}
	}
}
