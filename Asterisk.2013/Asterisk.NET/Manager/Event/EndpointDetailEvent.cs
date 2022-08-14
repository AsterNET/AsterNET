namespace AsterNET.Manager.Event
{
	public class EndpointDetailEvent : ResponseEvent
	{
		public EndpointDetailEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}