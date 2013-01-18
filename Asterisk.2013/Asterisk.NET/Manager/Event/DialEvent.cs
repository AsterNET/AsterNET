namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A dial event is triggered whenever a phone attempts to dial someone.<br/>
	/// This event is implemented in <code>apps/app_dial.c</code>.<br/>
	/// Available since Asterisk 1.2.
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
		/// Creates a new DialEvent.
		/// </summary>
		public DialEvent(ManagerConnection source)
			: base(source)
		{
		}

		public string DialString
		{
			get { return this.dialString; }
			set { this.dialString = value; }
		}
		public string SubEvent
		{
			get { return this.subEvent; }
			set { this.subEvent = value; }
		}
		public string DialStatus
		{
			get { return this.dialStatus; }
			set { this.dialStatus = value; }
		}
		/// <summary>
		/// Returns the name of the source channel.
		/// </summary>
		public string Src
		{
			get { return src; }
			set { this.src = value; }
		}
		/// <summary>
		/// Get/Set the name of the destination channel.
		/// </summary>
		public string Destination
		{
			get { return destination; }
			set { this.destination = value; }
		}
		/// <summary>
		/// Get/Set the Caller*ID.
		/// </summary>
		public string CallerId
		{
			get { return callerId; }
			set { this.callerId = value; }
		}
		/// <summary>
		/// Get/Set the Caller*ID Name.
		/// </summary>
		public string CallerIdName
		{
			get { return callerIdName; }
			set { this.callerIdName = value; }
		}
		/// <summary>
		/// Get/Set the Caller*ID Number.
		/// </summary>
		public string CallerIdNum
		{
			get { return callerIdNum; }
			set { this.callerIdNum = value; }
		}
		/// <summary>
		/// Get/Set the unique ID of the source channel.
		/// </summary>
		public string SrcUniqueId
		{
			get { return srcUniqueId; }
			set { this.srcUniqueId = value; }
		}
		/// <summary>
		/// Get/Set the unique ID of the distination channel.
		/// </summary>
		public string DestUniqueId
		{
			get { return destUniqueId; }
			set { this.destUniqueId = value; }
		}
	}
}