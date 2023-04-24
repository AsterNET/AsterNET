namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     An AgentsCompleteEvent is triggered after the state of all agents has been reported in response to an AgentsAction.<br/>
    ///     Available since Asterisk 1.2<br/>
    /// </summary>
    /// <seealso cref="Manager.Action.AgentsAction"/>
    /// <seealso cref="Manager.Event.AgentsEvent"/>
    public class AgentsCompleteEvent : ResponseEvent
	{
        /// <summary>
        ///     Creates a new <see cref="AgentsCompleteEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public AgentsCompleteEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}