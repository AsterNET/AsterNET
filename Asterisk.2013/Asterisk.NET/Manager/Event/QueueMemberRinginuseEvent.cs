namespace AsterNET.Manager.Event
{
	/// <summary>
	/// Raised when a member's ringinuse setting is changed
	/// </summary>
	public class QueueMemberRinginuseEvent : AbstractQueueMemberEvent
	{
		/// <summary>
		/// Creates a new QueueMemberRinginuseEvent
		/// </summary>
		/// <param name="source">ManagerConnection passed through in the event.</param>
		public QueueMemberRinginuseEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}
