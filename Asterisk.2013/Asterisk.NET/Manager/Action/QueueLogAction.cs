namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     Adds custom entry in queue_log.
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_QueueLog">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_QueueLog</see>
    /// </summary>
    public class QueueLogAction : ManagerAction
    {
        /// <summary>
        ///     Creates a new empty <see cref="QueueLogAction"/>.
        /// </summary>
        public QueueLogAction()
        {
        }

        /// <summary>
        ///     Creates a new <see cref="QueueLogAction"/>.
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="event"></param>
        /// <param name="uniqueid"></param>
        /// <param name="interface"></param>
        /// <param name="message"></param>
        public QueueLogAction(string queue, string @event, string uniqueid, string @interface, string message)
        {
            Queue = queue;
            Event = @event;
            Uniqueid = uniqueid;
            Interface = @interface;
            Message = message;
        }

        /// <summary>
        ///     Get the name of this action, i.e. "QueueLog".
        /// </summary>
        public override string Action
        {
            get { return "QueueLog"; }
        }

        /// <summary>
        ///     Gets or sets the queue.
        /// </summary>
        public string Queue { get; set; }

        /// <summary>
        ///     Gets or sets the event.
        /// </summary>
        public string Event { get; set; }

        /// <summary>
        ///     Gets or sets the unique id.
        /// </summary>
        public string Uniqueid { get; set; }

        /// <summary>
        ///     Gets or sets the interface.
        /// </summary>
        public string Interface { get; set; }

        /// <summary>
        ///     Gets or sets the message.
        /// </summary>
        public string Message { get; set; }
    }
}