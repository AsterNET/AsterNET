namespace AspNetCore.AsterNET.Manager.Action
{
    public class QueueLogAction : ManagerAction
    {
        /// <summary>
        ///     Adds custom entry in queue_log.
        /// </summary>
        public QueueLogAction()
        {
        }

        /// <summary>
        ///     Adds custom entry in queue_log.
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

        public override string Action
        {
            get { return "QueueLog"; }
        }

        public string Queue { get; set; }

        public string Event { get; set; }

        public string Uniqueid { get; set; }

        public string Interface { get; set; }

        public string Message { get; set; }
    }
}