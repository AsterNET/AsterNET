namespace AsterNET.Manager.Event
{
    /// <summary>
    /// Raised when a Queue member's status has changed
    /// </summary>
    public class QueueMemberStatusEvent : AbstractQueueMemberEvent
    {
        /// <summary>
        /// Returns the name of the member's interface.<br/>
        /// E.g. the channel name or agent group.
        /// </summary>
        public new string MemberName { get; set; }

        /// <summary>
        /// Channel technology or location from which to read device state changes.<br />
        /// </summary>
        public new string StateInterface { get; set; }

        /// <summary>
        /// Get/Set if the added member is a dynamic or static queue member.
        /// "dynamic" if the added member is a dynamic queue member,
        /// "static" if the added member is a static queue member.
        /// </summary>
        public new string Membership { get; set; }

        /// <summary>
        /// Get/Set the penalty for the added member. When calls are distributed
        /// members with higher penalties are considered last.
        /// </summary>
        public new int Penalty { get; set; }

        /// <summary>
        /// Get/Set the number of calls answered by the member.
        /// </summary>
        public new int CallsTaken { get; set; }

        /// <summary>
        /// Get/Set the time (in seconds since 01/01/1970) the last successful call answered by the added member was hungup.
        /// </summary>
        public new long LastCall { get; set; }

        /// <summary>
        /// Evaluates <see langword="true"/> if member is in call,
        /// <see langword="false"/> after LastCall time is updated.<br />
        /// </summary>
        public new bool InCall { get; set; }

        /// <summary>
        /// Get/Set the status of this queue member.<br/>
        /// Valid status codes are:<br/>
        /// <list type="number" start="0">
        /// <item>AST_DEVICE_UNKNOWN</item>
        /// <item>AST_DEVICE_NOT_INUSE</item>
        /// <item>AST_DEVICE_INUSE</item>
        /// <item>AST_DEVICE_BUSY</item>
        /// <item>AST_DEVICE_INVALID</item>
        /// <item>AST_DEVICE_UNAVAILABLE</item>
        /// <item>AST_DEVICE_RINGING</item>
        /// <item>AST_DEVICE_RINGINUSE</item>
        /// <item>AST_DEVICE_ONHOLD</item>
        /// </list>
        /// </summary>
        public new int Status { get; set; }

        /// <summary>
        /// Get/Set value if this queue member is paused (not accepting calls).<br/>
        /// true if this member has been paused or false if not.
        /// </summary>
        public new bool Paused { get; set; }

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