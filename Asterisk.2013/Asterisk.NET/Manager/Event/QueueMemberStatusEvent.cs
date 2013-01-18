namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A QueueMemberStatusEvent shows the status of a QueueMemberEvent
	/// </summary>
	public class QueueMemberStatusEvent : QueueMemberEvent
	{
		public QueueMemberStatusEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}