namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A StatusCompleteEvent is triggered after the state of all channels has been reported in response
	/// to a StatusAction.
	/// </summary>
	/// <seealso cref="Manager.Action.StatusAction"/>
	/// <seealso cref="Manager.event.StatusEvent"/>
	public class StatusCompleteEvent : ResponseEvent
	{
		private int items;

		public int Items
		{
			get { return this.items; }
			set { this.items = value; }
		}

		public StatusCompleteEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}