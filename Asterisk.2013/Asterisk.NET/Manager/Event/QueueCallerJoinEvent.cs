namespace AsterNET.Manager.Event
{
    /// <summary>
    /// A QueueCallerJoinEvent is triggered when a channel joins a queue.<br/>
    /// </summary>
    public class QueueCallerJoinEvent : QueueEvent
    {
        public string Position { get; set; }

        public QueueCallerJoinEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}