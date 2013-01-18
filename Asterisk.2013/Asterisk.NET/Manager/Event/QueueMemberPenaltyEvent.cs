namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A QueueMemberPenaltyEvent is triggered when a queue member is assigned a new penalty.
	/// </summary>
	public class QueueMemberPenaltyEvent : AbstractQueueMemberEvent
	{
		private int penalty;

		/// <summary>
		/// Get/Set the penalty for the queue location.
		/// </summary>
		public int Penalty
		{
			get { return this.penalty; }
			set { this.penalty = value; }
		}

		public QueueMemberPenaltyEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}
