namespace AsterNET.Manager.Event
{
	/// <summary>
	///     Abstract base class for several agent related events.
	/// </summary>
	public abstract class ConnectionStateEvent : ManagerEvent
	{
		private bool reconnect = false;
		/// <summary>
		///     Get/Set reconnect status.
		/// </summary>
		public bool Reconnect
		{
			get { return this.reconnect; }
			set { this.reconnect = value; }
		}

        /// <summary>
        ///     Creates a new <see cref="ConnectionStateEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        /// <param name="source"></param>
        public ConnectionStateEvent(ManagerConnection source)
			: base(source)
		{ }
	}
}
