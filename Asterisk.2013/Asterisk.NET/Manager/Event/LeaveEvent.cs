namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     A LeaveEvent is triggered when a channel leaves a queue.<br/>
    ///     It is implemented in apps/app_queue.c<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+11+ManagerEvent_Leave">https://wiki.asterisk.org/wiki/display/AST/Asterisk+11+ManagerEvent_Leave</see>
    /// </summary>
    public class LeaveEvent : QueueEvent
	{
        /// <summary>
        ///     Creates a new <see cref="LeaveEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public LeaveEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}