namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Raised when a MeetMe user has started talking.<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_MeetmeTalkRequest">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_MeetmeTalkRequest</see>
    /// </summary>
    public class MeetmeTalkRequestEvent : AbstractMeetmeEvent
    {
        /// <summary>
        ///     Creates a new <see cref="MeetmeTalkRequestEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        /// <param name="source"></param>
        public MeetmeTalkRequestEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        ///     Gets or sets a value indicating the meet me talk request status.
        /// </summary>
        public bool Status { get; set; }
    }
}