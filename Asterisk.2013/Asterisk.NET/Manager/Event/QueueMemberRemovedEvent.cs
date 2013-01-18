namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A QueueMemberRemovedEvent is triggered when a queue member is removed from a queue.<br/>
	/// It is implemented in <code>apps/app_queue.c</code>.<br/>
	/// Available since Asterisk 1.2
	/// </summary>
	public class QueueMemberRemovedEvent : AbstractQueueMemberEvent
	{
		private string memberName;

		/// <summary>
		/// Returns the name of the member's interface.<br/>
		/// E.g. the channel name or agent group.
		/// </summary>
		public string MemberName
		{
			get { return this.memberName; }
			set { this.memberName = value; }
		}

		public QueueMemberRemovedEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}