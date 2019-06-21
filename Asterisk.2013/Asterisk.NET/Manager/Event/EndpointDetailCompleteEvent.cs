namespace AsterNET.Manager.Event
{
	public class EndpointDetailCompleteEvent : ResponseEvent
	{
		public EndpointDetailCompleteEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}