namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     An AgentsCompleteEvent is triggered after the state of all agents has been reported in response to an AgentsAction.<br/>
    ///     Available since Asterisk 1.2<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_AgentsComplete">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_AgentsComplete</see>
    /// </summary>
    /// <seealso cref="Manager.Action.AgentsAction" />
    public class AgentsCompleteEvent : ResponseEvent
	{
        /// <summary>
        ///     Creates a new <see cref="AgentsCompleteEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        /// <param name="source"></param>
        public AgentsCompleteEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}