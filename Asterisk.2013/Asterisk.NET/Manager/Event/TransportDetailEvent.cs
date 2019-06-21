namespace AsterNET.Manager.Event
{
	public class TransportDetailEvent : ResponseEvent
	{
		public TransportDetailEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}