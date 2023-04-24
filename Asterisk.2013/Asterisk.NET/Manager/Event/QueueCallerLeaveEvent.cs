namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     A QueueCallerLeaveEvent is triggered when a channel leaves a queue.<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_QueueCallerLeave">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_QueueCallerLeave</see>
    /// </summary>
    public class QueueCallerLeaveEvent : LeaveEvent
	{
        // "Channel" in ManagerEvent.cs

        // "Queue" in QueueEvent.cs

        // "Count" in QueueEvent.cs

        /// <summary>
        ///     Creates a new <see cref="QueueCallerLeaveEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection" /></param>
        public QueueCallerLeaveEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}
