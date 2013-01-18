namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A DNDStateEvent is triggered by the Zap channel driver when a channel enters
	/// or leaves DND (do not disturb) state.<br/>
	/// It is implemented in <code>channels/chan_zap.c</code>.<br/>
	/// Available since Asterisk 1.2
	/// </summary>
	public class DNDStateEvent : ManagerEvent
	{
		private string state;
		private string status;

		/// <summary>
		/// Get/Set DND state of the channel. "enabled" if do not disturb is on, "disabled" if it is off.
		/// </summary>
		public string State
		{
			get { return this.state; }
			set { this.state = value; }
		}

		/// <summary>
		/// Get/Set DND state of the channel. "enabled" if do not disturb is on, "disabled" if it is off.
		/// </summary>
		public string Status
		{
			get { return this.status; }
			set { this.status = value; }
		}

		/// <summary>
		/// Creates a new DNDStateEvent.
		/// </summary>
		public DNDStateEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}