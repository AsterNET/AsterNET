namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Raised when a MeetMe conference ends.<br />
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_MeetmeEnd">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_MeetmeEnd</see>
    /// </summary>
    public class MeetmeEndEvent : AbstractMeetmeEvent
	{
        /// <summary>
        ///     Creates a new <see cref="MeetmeEndEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public MeetmeEndEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}