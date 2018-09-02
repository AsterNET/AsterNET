namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     A MeetMeJoinEvent is triggered if a channel joins a meet me conference.<br />
    ///     It is implemented in apps/app_meetme.c<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_MeetmeJoin">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_MeetmeJoin</see>
    /// </summary>
    public class MeetmeJoinEvent : AbstractMeetmeEvent
    {
        /// <summary>
        ///     Creates a new <see cref="MeetmeJoinEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        /// <param name="source"></param>
        public MeetmeJoinEvent(ManagerConnection source)
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
    }
}