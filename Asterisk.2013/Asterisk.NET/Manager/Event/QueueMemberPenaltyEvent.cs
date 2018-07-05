namespace AsterNET.Manager.Event
{
	/// <summary>
	/// A QueueMemberPenaltyEvent is triggered when a queue member is assigned a new penalty.
	/// </summary>
	public class QueueMemberPenaltyEvent : AbstractQueueMemberEvent
	{
		/// <summary>
		/// Creates a new QueueMemberPenaltyEvent
		/// </summary>
		/// <param name="source">ManagerConnection passed through in the event.</param>
		public QueueMemberPenaltyEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}
