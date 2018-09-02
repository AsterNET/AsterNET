namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     A MeetMeTalkingEvent is triggered when a user starts talking in a meet me conference.<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_MeetmeTalking">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_MeetmeTalking</see>
    /// </summary>
    public class MeetmeTalkingEvent : AbstractMeetmeEvent
    {
        /// <summary>
        ///     Creates a new <see cref="MeetmeTalkingEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public MeetmeTalkingEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        ///     Gets or sets a value indicating the talking status.
        /// </summary>
        public bool Status { get; set; }
    }
}