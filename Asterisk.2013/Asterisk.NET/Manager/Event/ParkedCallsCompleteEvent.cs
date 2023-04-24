namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     A ParkedCallsCompleteEvent is triggered after all parked calls have been reported in response to a ParkedCallsAction.<br/>
    /// </summary>
    /// <seealso cref="Manager.Action.ParkedCallsAction"/>
    /// <seealso cref="Manager.Event.ParkedCallEvent"/>
    public class ParkedCallsCompleteEvent : ResponseEvent
	{
        /// <summary>
        ///     Creates a new <see cref="ParkedCallsCompleteEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public ParkedCallsCompleteEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}