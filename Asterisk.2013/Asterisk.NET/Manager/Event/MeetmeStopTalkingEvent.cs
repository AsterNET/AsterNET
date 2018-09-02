namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     A MeetMeStopTalkingEvent is triggered when a user ends talking in a meet me conference.<br/>
    ///     It is implemented in apps/app_meetme.c
    /// </summary>
    public class MeetmeStopTalkingEvent : AbstractMeetmeEvent
	{
        /// <summary>
        ///     Creates a new <see cref="MeetmeStopTalkingEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        /// <param name="source"></param>
		public MeetmeStopTalkingEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}