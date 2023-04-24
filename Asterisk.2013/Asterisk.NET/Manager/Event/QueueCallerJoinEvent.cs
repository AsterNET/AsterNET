namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     A QueueCallerJoinEvent is triggered when a channel joins a queue.<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_QueueCallerJoin">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_QueueCallerJoin</see>
    /// </summary>
    public class QueueCallerJoinEvent : JoinEvent
	{
        // "Channel" in ManagerEvent.cs

        // "Queue" in QueueEvent.cs

        // "CallerId" in JoinEvent.cs

        // "CallerIdName" in JoinEvent.cs

        // "Position" in JoinEvent.cs

        /// <summary>
        ///     Creates a new <see cref="QueueCallerJoinEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection" /></param>
        public QueueCallerJoinEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}
