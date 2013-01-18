namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	///  Abstract base class for several call parking related events.
	/// </summary>
	public abstract class AbstractParkedCallEvent : ManagerEvent
	{
		private string exten;
		private string callerId;
		private string callerIdNum;
		private string callerIdName;
		
		/// <summary>
		/// Get/Set the extension the channel is or was parked at.
		/// </summary>
		public string Exten
		{
			get { return this.exten; }
			set { this.exten = value; }
		}
		/// <summary>
		/// Get/Set the Caller*ID number of the parked channel.
		/// </summary>
		public string CallerId
		{
			get { return this.callerId; }
			set { this.callerId = value; }
		}
		/// <summary>
		/// Get/Set the Caller*ID number of the parked channel.
		/// </summary>
		public string CallerIdNum
		{
			get { return this.callerIdNum; }
			set { this.callerIdNum = value; }
		}
		/// <summary>
		/// Get/Set the Caller*ID name of the parked channel.
		/// </summary>
		public string CallerIdName
		{
			get { return this.callerIdName; }
			set { this.callerIdName = value; }
		}

		public AbstractParkedCallEvent(ManagerConnection source)
			: base(source)
		{ }
	}
}