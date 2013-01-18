namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A CdrEvent is triggered when a call detail record is generated, usually at the end of a call.<br/>
	/// To enable CdrEvents you have to add <code>enabled = yes</code> to the general section in
	/// <code>cdr_manager.conf</code>.<br/>
	/// This event is implemented in <code>cdr/cdr_manager.c</code>
	/// </summary>
	public class CdrEvent : ManagerEvent
	{
		private string accountCode;
		private string src;
		private string destination;
		private string destinationContext;
		private string callerId;
		private string destinationChannel;
		private string lastApplication;
		private string lastData;
		private string startTime;
		private string answerTime;
		private string endTime;
		private long duration;
		private long billableSeconds;
		private string disposition;
		private string amaFlags;
		private string userField;

		public CdrEvent(ManagerConnection source)
			: base(source)
		{
		}

		public string AccountCode
		{
			get { return accountCode; }
			set { this.accountCode = value; }
		}
		public string Src
		{
			get { return src; }
			set { this.src = value; }
		}
		public string Destination
		{
			get { return destination; }
			set { this.destination = value; }
		}
		public string DestinationContext
		{
			get { return destinationContext; }
			set { this.destinationContext = value; }
		}
		public string CallerId
		{
			get { return callerId; }
			set { this.callerId = value; }
		}
		public string DestinationChannel
		{
			get { return destinationChannel; }
			set { this.destinationChannel = value; }
		}
		public string LastApplication
		{
			get { return lastApplication; }
			set { this.lastApplication = value; }
		}
		public string LastData
		{
			get { return lastData; }
			set { this.lastData = value; }
		}
		public string StartTime
		{
			get { return startTime; }
			set { this.startTime = value; }
		}
		public string AnswerTime
		{
			get { return answerTime; }
			set { this.answerTime = value; }
		}
		public string EndTime
		{
			get { return endTime; }
			set { this.endTime = value; }
		}
		public long Duration
		{
			get { return duration; }
			set { this.duration = value; }
		}
		public long BillableSeconds
		{
			get { return billableSeconds; }
			set { this.billableSeconds = value; }
		}
		public string Disposition
		{
			get { return disposition; }
			set { this.disposition = value; }
		}
		public string AmaFlags
		{
			get { return amaFlags; }
			set { this.amaFlags = value; }
		}
		public string UserField
		{
			get { return userField; }
			set { this.userField = value; }
		}
	}
}