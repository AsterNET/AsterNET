namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// Abstract base class for several agent related events.
	/// </summary>
	public abstract class ConnectionStateEvent : ManagerEvent
	{
		private bool reconnect = false;
		/// <summary>
		/// Get/Set reconnect status.
		/// </summary>
		public bool Reconnect
		{
			get { return this.reconnect; }
			set { this.reconnect = true; }
		}

		public ConnectionStateEvent(ManagerConnection source)
			: base(source)
		{ }
	}
}