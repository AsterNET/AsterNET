namespace AsterNET.Manager.Event
{
	/// <summary>
	/// A QueueCallerJoinEvent is triggered when a channel joins a queue.<br/>
	/// </summary>
	public class QueueCallerJoinEvent : JoinEvent
	{
		// "Channel" in ManagerEvent.cs
		
		// "Queue" in QueueEvent.cs
		
		// "CallerId" in JoinEvent.cs
		
		// "CallerIdName" in JoinEvent.cs
		
		// "Position" in JoinEvent.cs
		
		public QueueCallerJoinEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}
