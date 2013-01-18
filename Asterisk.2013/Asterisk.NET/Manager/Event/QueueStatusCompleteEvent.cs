namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A QueueStatusCompleteEvent is triggered after the state of all queues has been reported in response to a QueueStatusAction.<br/>
	/// Since Asterisk 1.2
	/// </summary>
	/// <seealso cref="Manager.Action.QueueStatusAction" />
	public class QueueStatusCompleteEvent : ResponseEvent
	{
		public QueueStatusCompleteEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}