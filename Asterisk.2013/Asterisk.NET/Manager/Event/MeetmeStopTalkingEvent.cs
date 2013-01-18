namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A MeetMeStopTalkingEvent is triggered when a user ends talking in a meet me conference.<br/>
	/// It is implemented in <code>apps/app_meetme.c</code>
	/// </summary>
	public class MeetmeStopTalkingEvent : AbstractMeetmeEvent
	{
		public MeetmeStopTalkingEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}