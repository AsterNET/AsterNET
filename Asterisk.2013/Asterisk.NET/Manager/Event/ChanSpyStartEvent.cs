namespace AsterNET.Manager.Event
{
	/// <summary>
	/// Raised when one channel begins spying on another channel.
	/// </summary>
	public class ChanSpyStartEvent : AbstractChanSpyEvent
	{
		/// <inheritdoc />
		public ChanSpyStartEvent(ManagerConnection source) : base(source)
		{
		}
	}
}
