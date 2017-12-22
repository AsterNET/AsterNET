namespace AsterNET.Manager.Event
{
	/// <summary>
	/// Raised when a Queue member's status has changed
	/// </summary>
	public class QueueMemberStatusEvent : AbstractQueueMemberEvent
	{
		/// <summary>
		/// Creates a new QueueMemberStatusEvent
		/// </summary>
		/// <param name="source">ManagerConnection passed through in the event.</param>
		public QueueMemberStatusEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}
