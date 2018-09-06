namespace AsterNET.Manager.Event
{
	/// <summary>
	///     A QueueMemberAddedEvent is triggered when a queue member is added to a queue.<br/>
	///     It is implemented in apps/app_queue.c.<br/>
	///     <b>Available since : </b> <see href="http://www.voip-info.org/wiki/view/Asterisk+v1.2" target="_blank" alt="Asterisk 1.2 wiki docs">Asterisk 1.2</see>.
	/// </summary>
	public class QueueMemberAddedEvent : AbstractQueueMemberEvent
	{
		/// <summary>
		///     Creates a new <see cref="QueueMemberAddedEvent"/>
		/// </summary>
		/// <param name="source"><see cref="ManagerConnection"/></param>
		public QueueMemberAddedEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}
