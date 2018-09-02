namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     A JoinEvent is triggered when a channel joins a queue.<br />
    ///     It is implemented in apps/app_queue.c<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+11+ManagerEvent_Join">https://wiki.asterisk.org/wiki/display/AST/Asterisk+11+ManagerEvent_Join</see>
    /// </summary>
    public class JoinEvent : QueueEvent
    {
        /// <summary>
        ///     Creates a new <see cref="JoinEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public JoinEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        ///     Get/Set the Caller*ID number of the channel that joined the queue if set.<br/>
        ///     If the channel has no caller id set "unknown" is returned.
        /// </summary>
        public string CallerId { get; set; }

        /// <summary>
        ///     Get/Set the Caller*ID name of the channel that joined the queue if set.<br/>
        ///     If the channel has no caller id set "unknown" is returned.
        /// </summary>
        public string CallerIdName { get; set; }

        /// <summary>
        ///     Get/Set the position of the joined channel in the queue.
        /// </summary>
        public int Position { get; set; }
    }
}