using System;

namespace AspNetCore.AsterNET.Manager.Event
{
	/// <summary>
	/// A QueueMemberPausedEvent is triggered when a queue member is paused or unpaused.<br/>
	/// It is implemented in apps/app_queue.c.<br/>
	/// <para>
	/// <b>Available since : </b> <see href="http://www.voip-info.org/wiki/view/Asterisk+v1.2" target="_blank" alt="Asterisk 1.2 wiki docs">Asterisk 1.2</see>.<br/>
	/// <b>Replaced by : </b> <see cref="QueueMemberPauseEvent"/> since <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+Documentation" target="_blank" alt="Asterisk 12 wiki docs">Asterisk 12</see>.<br/>
	/// <b>Removed since : </b> <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+13+Documentation" target="_blank" alt="Asterisk 13 wiki docs">Asterisk 13</see>.<br/>
	/// </para>
	/// </summary>
	public class QueueMemberPausedEvent : AbstractQueueMemberEvent
	{
		/// <summary>
		/// The reason a member was paused
		/// </summary>
		public string Reason { get; set; }
		
		/// <summary>
		/// Creates a new QueueMemberPausedEvent
		/// </summary>
		/// <param name="source">ManagerConnection passed through in the event.</param>
		public QueueMemberPausedEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}
