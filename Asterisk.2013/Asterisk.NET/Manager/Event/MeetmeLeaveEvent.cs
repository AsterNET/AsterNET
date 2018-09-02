namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     A MeetMeLeaveEvent is triggered if a channel leaves a meet me conference.<br />
    ///     It is implemented in apps/app_meetme.c<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_MeetmeLeave">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_MeetmeLeave</see>
    /// </summary>
    public class MeetmeLeaveEvent : AbstractMeetmeEvent
    {
        /// <summary>
        ///     Creates a new <see cref="MeetmeLeaveEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        /// <param name="source"></param>
        public MeetmeLeaveEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        ///     Gets or sets the Caller*ID number.
        /// </summary>
        public string CallerIdNum { get; set; }

        /// <summary>
        ///     Gets or sets the Caller*ID name.
        /// </summary>
        public string CallerIdName { get; set; }

        /// <summary>
        ///     Gets or sets the duration, in seconds.
        /// </summary>
        public long Duration { get; set; }
    }
}