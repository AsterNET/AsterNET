namespace AsterNET.Manager.Event
{
	public class AuthDetailEvent : ResponseEvent
	{
		public AuthDetailEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}