namespace AsterNET.Manager.Event
{
	/// <summary>
	/// A LeaveEvent is triggered when a channel leaves a queue.<br/>
	/// It is implemented in apps/app_queue.c
	/// </summary>
	public class LeaveEvent : QueueEvent
	{
		public LeaveEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}