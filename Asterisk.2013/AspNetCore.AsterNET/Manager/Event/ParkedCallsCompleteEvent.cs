namespace AspNetCore.AsterNET.Manager.Event
{
    /// <summary>
    /// A ParkedCallsCompleteEvent is triggered after all parked calls have been reported in response to a ParkedCallsAction.
    /// </summary>
    /// <seealso cref="Manager.Action.ParkedCallsAction"/>
    /// <seealso cref="Manager.Event.ParkedCallEvent"/>
    public class ParkedCallsCompleteEvent : ResponseEvent
	{
		public ParkedCallsCompleteEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}