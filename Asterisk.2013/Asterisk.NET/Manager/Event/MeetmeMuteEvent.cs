namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Raised when a MeetMe user is muted or unmuted.<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_MeetmeMute">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_MeetmeMute</see>
    /// </summary>
    public class MeetmeMuteEvent : AbstractMeetmeEvent
    {
        /// <summary>
        ///     Creates a new <see cref="MeetmeMuteEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        /// <param name="source"></param>
        public MeetmeMuteEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        ///     Gets or sets a value indicating the mute status.
        /// </summary>
        public bool Status { get; set; }
    }
}