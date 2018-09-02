namespace AsterNET.Manager.Event
{
	/// <summary>
	///     A dial event is triggered whenever a phone attempts to dial someone.<br/>
	///     This event is implemented in apps/app_dial.c.<br/>
	///     Available since Asterisk 1.2.
	/// </summary>
	public class DialEvent : ManagerEvent
	{
		private string subEvent;
		private string destination;
		private string callerId;
		private string callerIdNum;
		private string callerIdName;
		private string srcUniqueId;
		private string destUniqueId;
		private string dialString;
		private string dialStatus;
		private string src;


        /// <summary>
        ///     Creates a new <see cref="DialEvent" />.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public DialEvent(ManagerConnection source)
			: base(source)
		{
		}

        /// <summary>
        ///     Gets or sets the dial string.
        /// </summary>
        public string DialString
		{
			get { return this.dialString; }
			set { this.dialString = value; }
		}

        /// <summary>
        ///     Gets or sets the sub event.
        /// </summary>
        public string SubEvent
		{
			get { return this.subEvent; }
			set { this.subEvent = value; }
		}
        /// <summary>
        ///     Gets or sets the dial status.
        /// </summary>
        public string DialStatus
		{
			get { return this.dialStatus; }
			set { this.dialStatus = value; }
		}
		/// <summary>
		///     Returns the name of the source channel.
		/// </summary>
		public string Src
		{
			get { return src; }
			set { this.src = value; }
		}
		/// <summary>
		///     Get/Set the name of the destination channel.
		/// </summary>
		public string Destination
		{
			get { return destination; }
			set { this.destination = value; }
		}
		/// <summary>
		///     Get/Set the Caller*ID.
		/// </summary>
		public string CallerId
		{
			get { return callerId; }
			set { this.callerId = value; }
		}
		/// <summary>
		///     Get/Set the Caller*ID Name.
		/// </summary>
		public string CallerIdName
		{
			get { return callerIdName; }
			set { this.callerIdName = value; }
		}
		/// <summary>
		///     Get/Set the Caller*ID Number.
		/// </summary>
		public string CallerIdNum
		{
			get { return callerIdNum; }
			set { this.callerIdNum = value; }
		}
		/// <summary>
		///     Get/Set the unique ID of the source channel.
		/// </summary>
		public string SrcUniqueId
		{
			get { return srcUniqueId; }
			set { this.srcUniqueId = value; }
		}
		/// <summary>
		///     Get/Set the unique ID of the destination channel.
		/// </summary>
		public string DestUniqueId
		{
			get { return destUniqueId; }
			set { this.destUniqueId = value; }
		}
	}
}