namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A LeaveEvent is triggered when a channel leaves a queue.<br/>
	/// It is implemented in <code>apps/app_queue.c</code>
	/// </summary>
	public class LeaveEvent : QueueEvent
	{
		public LeaveEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}