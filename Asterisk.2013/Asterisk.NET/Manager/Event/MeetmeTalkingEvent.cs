namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A MeetMeTalkingEvent is triggered when a user starts talking in a meet me conference.
	/// </summary>
	public class MeetmeTalkingEvent : AbstractMeetmeEvent
	{
		private bool status;

		public bool Status
		{
			get { return this.status; }
			set { this.status = value; }
		}

		public MeetmeTalkingEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}