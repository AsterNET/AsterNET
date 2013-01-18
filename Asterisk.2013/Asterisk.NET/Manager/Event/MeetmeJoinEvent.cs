namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A MeetMeJoinEvent is triggered if a channel joins a meet me conference.<br/>
	/// It is implemented in <code>apps/app_meetme.c</code>
	/// </summary>
	public class MeetmeJoinEvent : AbstractMeetmeEvent
	{
		private string callerIdNum;
		private string callerIdName;

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

		public MeetmeJoinEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}