namespace AsterNET.Manager.Event
{
	/// <summary>
	/// Raised when a channel has stopped spying.
	/// </summary>
	public class ChanSpyStopEvent : AbstractChanSpyEvent
	{
		/// <inheritdoc />
		public ChanSpyStopEvent(ManagerConnection source) : base(source)
		{
		}
	}
}