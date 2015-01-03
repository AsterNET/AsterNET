using AsterNET.FastAGI.Command;
using AsterNET.IO;

namespace AsterNET.FastAGI
{
    /// <summary>
    ///     Default implementation of the AGIChannel interface.
    /// </summary>
    public class AGIChannel
    {
        private readonly bool _SC511_CAUSES_EXCEPTION;
        private readonly bool _SCHANGUP_CAUSES_EXCEPTION;
        private readonly AGIReader agiReader;
        private readonly AGIWriter agiWriter;
        private AGIReply agiReply;


        public AGIChannel(SocketConnection socket, bool SC511_CAUSES_EXCEPTION, bool SCHANGUP_CAUSES_EXCEPTION)
        {
            agiWriter = new AGIWriter(socket);
            agiReader = new AGIReader(socket);

            _SC511_CAUSES_EXCEPTION = SC511_CAUSES_EXCEPTION;
            _SCHANGUP_CAUSES_EXCEPTION = SCHANGUP_CAUSES_EXCEPTION;
        }

        public AGIChannel(AGIWriter agiWriter, AGIReader agiReader, bool SC511_CAUSES_EXCEPTION,
            bool SCHANGUP_CAUSES_EXCEPTION)
        {
            this.agiWriter = agiWriter;
            this.agiReader = agiReader;

            _SC511_CAUSES_EXCEPTION = SC511_CAUSES_EXCEPTION;
            _SCHANGUP_CAUSES_EXCEPTION = SCHANGUP_CAUSES_EXCEPTION;
        }

        /// <summary>
        ///     Get last AGI Reply.
        /// </summary>
        public AGIReply LastReply
        {
            get { return agiReply; }
        }

        public AGIReply SendCommand(AGICommand command)
        {
            agiWriter.SendCommand(command);
            agiReply = agiReader.ReadReply();
            int status = agiReply.GetStatus();
            if (status == (int) AGIReplyStatuses.SC_INVALID_OR_UNKNOWN_COMMAND)
                throw new InvalidOrUnknownCommandException(command.BuildCommand());
            if (status == (int) AGIReplyStatuses.SC_INVALID_COMMAND_SYNTAX)
                throw new InvalidCommandSyntaxException(agiReply.GetSynopsis(), agiReply.GetUsage());
            if (status == (int) AGIReplyStatuses.SC_DEAD_CHANNEL && _SC511_CAUSES_EXCEPTION)
                throw new AGIHangupException();
            if ((status == 0) && agiReply.FirstLine == "HANGUP" && _SCHANGUP_CAUSES_EXCEPTION)
                throw new AGIHangupException();
            return agiReply;
        }
    }
}