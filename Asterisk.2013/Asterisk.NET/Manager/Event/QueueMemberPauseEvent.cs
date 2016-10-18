using System;

namespace AsterNET.Manager.Event
{
    /// <summary>
    /// Raised when a member is paused/unpaused in the queue.<br />
    /// <b>Available since : </b> <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+Documentation" target="_blank" alt="Asterisk 12 wiki docs">Asterisk 12</see>.
    /// </summary>
    public class QueueMemberPauseEvent : AbstractQueueMemberEvent
    {
        /// <summary>
        /// The reason a member was paused.
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Creates a new QueueMemberPauseEvent
        /// </summary>
        /// <param name="source">ManagerConnection passed through in the event.</param>
        public QueueMemberPauseEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}