namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A MeetMeLeaveEvent is triggered if a channel leaves a meet me conference.<br/>
	/// It is implemented in <code>apps/app_meetme.c</code>
	/// </summary>
	public class MeetmeLeaveEvent : AbstractMeetmeEvent
	{
		private string callerIdNum;
		private string callerIdName;
		private long duration;

		public string CallerIdNum
		{
			get { return this.callerIdNum; }
			set { this.callerIdNum = value; }
		}
		public string CallerIdName
		{
			get { return this.callerIdName; }
			set { this.callerIdName = value; }
		}

		public long Duration
		{
			get { return this.duration; }
			set { this.duration = value; }
		}

		public MeetmeLeaveEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}