namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// An UnholdEvent is triggered by the SIP channel driver when a channel is no longer put on hold.<br/>
	/// It is implemented in <code>channels/chan_sip.c</code>.<br/>
	/// Available since Asterisk 1.2
	/// </summary>
	/// <seealso cref="Manager.event.HoldEvent"/>
	public class UnholdEvent : ManagerEvent
	{
		/// <summary>
		/// Creates a new UnholdEvent.
		/// </summary>
		public UnholdEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}