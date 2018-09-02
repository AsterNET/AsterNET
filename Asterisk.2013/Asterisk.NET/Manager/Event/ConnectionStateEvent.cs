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
        ///     Creates a new <see cref="ConnectionStateEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public ConnectionStateEvent(ManagerConnection source)
			: base(source)
		{ }
	}
}
