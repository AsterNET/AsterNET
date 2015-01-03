namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     A MeetMeTalkingEvent is triggered when a user starts talking in a meet me conference.
    /// </summary>
    public class MeetmeTalkingEvent : AbstractMeetmeEvent
    {
        public MeetmeTalkingEvent(ManagerConnection source)
            : base(source)
        {
        }

        public bool Status { get; set; }
    }
}