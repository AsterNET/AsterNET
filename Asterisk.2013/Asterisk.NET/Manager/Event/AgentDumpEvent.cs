namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     An AgentDumpEvent is triggered when an agent dumps the caller while listening
    ///     to the queue announcement.<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_AgentDump">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_AgentDump</see>
    /// </summary>
    public class AgentDumpEvent : AbstractAgentEvent
	{
        /// <summary>
        ///     Creates a new <see cref="AgentDumpEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        /// <param name="source"></param>
        public AgentDumpEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}