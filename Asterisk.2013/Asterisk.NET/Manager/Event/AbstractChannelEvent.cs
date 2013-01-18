namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// Abstract base class providing common properties for HangupEvent, NewChannelEvent and NewStateEvent.
	/// </summary>
	public abstract class AbstractChannelEvent : ManagerEvent
	{
		private string channelState;
		private string channelStateDesc;
		private string callerId;
		private string callerIdNum;
		private string callerIdName;
		private string accountCode;
		private string state;

		/// <summary>
		/// Get/Set Channel State
		/// </summary>
		public string ChannelState
		{
			get { return this.channelState; }
			set { this.channelState = value; }
		}

		/// <summary>
		/// Get/Set Channel State Description
		/// </summary>
		public string ChannelStateDesc
		{
			get { return this.channelStateDesc; }
			set { this.channelStateDesc = value; }
		}

		/// <summary>
		/// Get/Set the Caller*ID of the channel if set or &lt;unknown&gt; if none has been set.
		/// </summary>
		public string CallerId
		{
			get { return callerId; }
			set { this.callerId = value; }
		}
		/// <summary>
		/// Get/Set the Caller*ID of the channel if set or &lt;unknown&gt; if none has been set.
		/// </summary>
		public string CallerIdNum
		{
			get { return callerIdNum; }
			set { this.callerIdNum = value; }
		}
		/// <summary>
		/// Get/Set the Caller*ID Name of the channel if set or &lg;unknown&gt; if none has been set.
		/// </summary>
		public string CallerIdName
		{
			get { return callerIdName; }
			set { this.callerIdName = value; }
		}
		/// <summary>
		/// Get/Set the (new) state of the channel.<br/>
		/// The following states are used:<br/>
		/// <ul>
		/// <li>Down</li>
		/// <li>OffHook</li>
		/// <li>Dialing</li>
		/// <li>Ring</li>
		/// <li>Ringing</li>
		/// <li>Up</li>
		/// <li>Busy</li>
		/// <ul>
		/// </summary>
		public string State
		{
			get { return this.state; }
			set { this.state = value; }
		}

		/// <summary>
		/// Get/Set channel AccountCode
		/// </summary>
		public string AccountCode
		{
			get { return this.accountCode; }
			set { this.accountCode = value; }
		}

		public AbstractChannelEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}