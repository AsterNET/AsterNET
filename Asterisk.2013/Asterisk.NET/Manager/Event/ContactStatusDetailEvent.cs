namespace AsterNET.Manager.Event
{
	public class ContactStatusDetailEvent : ResponseEvent
	{
		public ContactStatusDetailEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}