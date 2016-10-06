namespace AsterNET.Manager.Event
{
    public class DTMFBeginEvent : ManagerEvent
    {
        /// <summary>
        ///     Creates a new DialEvent.
        /// </summary>
        public DTMFBeginEvent(ManagerConnection source)
            : base(source)
        {
        }

        public string Direction { get; set; }

        public string Digit { get; set; }
    }
}