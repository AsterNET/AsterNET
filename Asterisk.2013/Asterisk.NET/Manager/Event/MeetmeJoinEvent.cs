namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     A MeetMeJoinEvent is triggered if a channel joins a meet me conference.<br />
    ///     It is implemented in apps/app_meetme.c
    /// </summary>
    public class MeetmeJoinEvent : AbstractMeetmeEvent
    {
        public MeetmeJoinEvent(ManagerConnection source)
            : base(source)
        {
        }

        public string CallerIdNum { get; set; }

        public string CallerIdName { get; set; }
    }
}