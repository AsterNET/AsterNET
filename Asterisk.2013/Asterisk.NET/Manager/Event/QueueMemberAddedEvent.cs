namespace AsterNET.Manager.Event
{
    /// <summary>
    /// A QueueMemberAddedEvent is triggered when a queue member is added to a queue.<br/>
    /// It is implemented in apps/app_queue.c.<br/>
    /// <para>
    /// <b>Available since : </b> <see href="http://www.voip-info.org/wiki/view/Asterisk+v1.2" target="_blank" alt="Asterisk 1.2 wiki docs">Asterisk 1.2</see>.<br/>
    /// </para>
    /// </summary>
    public class QueueMemberAddedEvent : AbstractQueueMemberEvent
	{
		/// <summary>
		/// Returns the name of the member's interface.<br/>
		/// E.g. the channel name or agent group.
		/// </summary>
		public new string MemberName { get; set; }

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
        /// Creates a new QueueMemberAddedEvent
        /// </summary>
        /// <param name="source">ManagerConnection passed through in the event.</param>
        public QueueMemberAddedEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}