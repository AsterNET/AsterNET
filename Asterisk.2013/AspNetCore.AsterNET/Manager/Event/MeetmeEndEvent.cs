namespace AspNetCore.AsterNET.Manager.Event
{
	public class MeetmeEndEvent : AbstractMeetmeEvent
	{

		public MeetmeEndEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}