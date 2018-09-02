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
        ///     Creates a new <see cref="AgentDumpEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public AgentDumpEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}