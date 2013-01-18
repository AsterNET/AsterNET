namespace Asterisk.NET.Manager.Event
{
	public class MeetmeTalkRequestEvent : AbstractMeetmeEvent
	{
		private bool status;

		public bool Status
		{
			get { return this.status; }
			set { this.status = value; }
		}

		public MeetmeTalkRequestEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}