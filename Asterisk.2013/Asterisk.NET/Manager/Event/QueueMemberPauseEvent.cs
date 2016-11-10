using System;

namespace AsterNET.Manager.Event
{
    /// <summary>
    /// Raised when a member is paused/unpaused in the queue.<br />
    /// Available since Asterisk 12
    /// </summary>
    public class QueueMemberPauseEvent : AbstractQueueMemberEvent
    {
        /// <summary>
        /// The name of the queue member.
        /// </summary>
        public string MemberName { get; set; }

        /// <summary>
        /// Get/Set if this queue member is paused (not accepting calls).<br/>
        /// true if this member has been paused or
        /// false if not.
        /// </summary>
        public bool Paused { get; set; }

        /// <summary>
        /// The reason a member was paused.
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Set to 1 if member is in call. Set to 0 after LastCall time is updated.<br/>
        /// Available since Asterisk 13
        /// </summary>
        public string InCall { get; set; }

        /// <summary>
        /// If set when paused, the reason the queue member was paused.<br/>
        /// Available since Asterisk 13
        /// </summary>
        public string PausedReason { get; set; }

		public QueueMemberPauseEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}