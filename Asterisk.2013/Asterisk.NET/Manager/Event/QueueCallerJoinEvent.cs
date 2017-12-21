namespace AsterNET.Manager.Event
{
	/// <summary>
	/// A QueueCallerJoinEvent is triggered when a channel joins a queue.<br/>
	/// </summary>
	public class QueueCallerJoinEvent : JoinEvent
	{
		// "Channel" in ManagerEvent.cs
		
		// "Queue" in QueueEvent.cs
		
		/// <summary>
		///     Get/Set the Caller*ID number of the channel that joined the queue if set.
		///     If the channel has no caller id set "unknown" is returned.
		/// </summary>
		public string CallerIDNum { get; set; }
		
		// "CallerIdName" in JoinEvent.cs
		
		// "Position" in JoinEvent.cs
		
		public QueueCallerJoinEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}
