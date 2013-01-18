namespace Asterisk.NET.Manager.Event
{
	public class MeetmeMuteEvent : AbstractMeetmeEvent
	{
		private bool status;

		public bool Status
		{
			get { return this.status; }
			set { this.status = value; }
		}

		public MeetmeMuteEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}