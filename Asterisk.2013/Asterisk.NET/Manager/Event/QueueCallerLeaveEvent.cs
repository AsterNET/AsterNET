namespace AsterNET.Manager.Event
{
    /// <summary>
    /// A QueueCallerLeaveEvent is triggered when a channel leaves a queue.<br/>
    /// </summary>
    public class QueueCallerLeaveEvent : QueueEvent
    {
        public string Position { get; set; }

        public QueueCallerLeaveEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}