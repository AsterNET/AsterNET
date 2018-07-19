namespace AspNetCore.AsterNET.Manager.Event
{
    /// <summary>
    ///     A JoinEvent is triggered when a channel joines a queue.<br />
    ///     It is implemented in apps/app_queue.c
    /// </summary>
    public class JoinEvent : QueueEvent
    {
        public JoinEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        ///     Get/Set the Caller*ID number of the channel that joined the queue if set.
        ///     If the channel has no caller id set "unknown" is returned.
        /// </summary>
        public string CallerId { get; set; }

        /// <summary>
        ///     Get/Set the Caller*ID name of the channel that joined the queue if set.
        ///     If the channel has no caller id set "unknown" is returned.
        /// </summary>
        public string CallerIdName { get; set; }

        /// <summary>
        ///     Get/Set the position of the joined channel in the queue.
        /// </summary>
        public int Position { get; set; }
    }
}