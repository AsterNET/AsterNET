namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A ParkedCallEvent is triggered when a channel is parked (in this case no
	/// action id is set) and in response to a ParkedCallsAction.<br/>
	/// It is implemented in <code>res/res_features.c</code>
	/// </summary>
	/// <seealso cref="Manager.Action.ParkedCallsAction"/>
	public class ParkedCallEvent : ResponseEvent
	{
		private string exten;
		private string from;
		private long timeout;
		private string callerId;
		private string callerIdNum;
		private string callerIdName;

		/// <summary>Get/Set the extension the channel is parked at.</summary>
		public string Exten
		{
			get { return exten; }
			set { this.exten = value; }
		}
		/// <summary>Get/Set the name of the channel that parked the call.</summary>
		public string From
		{
			get { return from; }
			set { this.from = value; }
		}
		/// <summary>
		/// Get/Set the number of seconds this call will be parked.<br/>
		/// This corresponds to the <code>parkingtime</code> option in
		/// <code>features.conf</code>.
		/// </summary>
		public long Timeout
		{
			get { return timeout; }
			set { this.timeout = value; }
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

		public ParkedCallEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}