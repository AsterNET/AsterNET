namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     A MeetMeStopTalkingEvent is triggered when a user ends talking in a meet me conference.<br/>
    ///     To enable talker detection you must pass the option 'T' to the MeetMe application.<br/>
    ///     It is implemented in <code>apps/app_meetme.c</code><br/>
    ///     Available only in Asterisk 1.2. Asterisk 1.4 sends a <see cref="MeetmeTalkingEvent"/> with status set to <code>false</code> instead.
    /// </summary>
    public class MeetmeStopTalkingEvent : AbstractMeetmeEvent
	{
        /// <summary>
        ///     Creates a new <see cref="MeetmeStopTalkingEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
		public MeetmeStopTalkingEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}