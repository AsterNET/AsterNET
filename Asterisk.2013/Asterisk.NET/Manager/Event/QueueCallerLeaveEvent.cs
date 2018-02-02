namespace AsterNET.Manager.Event
{
	/// <summary>
	/// A QueueCallerLeaveEvent is triggered when a channel leaves a queue.<br/>
	/// </summary>
	public class QueueCallerLeaveEvent : LeaveEvent
	{
		// "Channel" in ManagerEvent.cs
		
		// "Queue" in QueueEvent.cs
		
		// "Count" in QueueEvent.cs
		
		public QueueCallerLeaveEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}
