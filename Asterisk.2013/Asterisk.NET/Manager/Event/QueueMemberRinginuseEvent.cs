namespace AsterNET.Manager.Event
{
    /// <summary>
    /// Raised when a member's ringinuse setting is changed
    /// </summary>
    public class QueueMemberRinginuseEvent : AbstractQueueMemberEvent
    {

        /// <summary>
        /// Evaluates <see langword="true"/> if Ringinuse,
        /// <see langword="false"/> if not.<br />
        /// </summary>
        public new bool Ringinuse { get; set; }

        /// <summary>
        /// Creates a new QueueMemberRinginuseEvent
        /// </summary>
        /// <param name="source">ManagerConnection passed through in the event.</param>
		public QueueMemberRinginuseEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}