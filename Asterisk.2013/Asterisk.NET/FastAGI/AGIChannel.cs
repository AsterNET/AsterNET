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

        private bool _SC511_CAUSES_EXCEPTION = false;
        private bool _SCHANGUP_CAUSES_EXCEPTION = false;

        
        public AGIChannel(IO.SocketConnection socket, bool SC511_CAUSES_EXCEPTION, bool SCHANGUP_CAUSES_EXCEPTION)
        {
            this.agiWriter = new AGIWriter(socket);
            this.agiReader = new AGIReader(socket);

            this._SC511_CAUSES_EXCEPTION = SC511_CAUSES_EXCEPTION;
            this._SCHANGUP_CAUSES_EXCEPTION = SCHANGUP_CAUSES_EXCEPTION;
        }

        public AGIChannel(AGIWriter agiWriter, AGIReader agiReader, bool SC511_CAUSES_EXCEPTION, bool SCHANGUP_CAUSES_EXCEPTION)
		{
			this.agiWriter = agiWriter;
			this.agiReader = agiReader;

            this._SC511_CAUSES_EXCEPTION = SC511_CAUSES_EXCEPTION;
            this._SCHANGUP_CAUSES_EXCEPTION = SCHANGUP_CAUSES_EXCEPTION;
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
            else if (status == (int)AGIReplyStatuses.SC_DEAD_CHANNEL && _SC511_CAUSES_EXCEPTION)
                throw new AGIHangupException();
            else if ((status == 0) && agiReply.FirstLine == "HANGUP" && _SCHANGUP_CAUSES_EXCEPTION)
                throw new AGIHangupException();
			return agiReply;
		}
	}
}
