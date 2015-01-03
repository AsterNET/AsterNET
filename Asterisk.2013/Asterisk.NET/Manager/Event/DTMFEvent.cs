namespace AsterNET.Manager.Event
{
    public class DTMFEvent : ManagerEvent
    {
        /// <summary>
        ///     Creates a new DialEvent.
        /// </summary>
        public DTMFEvent(ManagerConnection source)
            : base(source)
        {
        }

        public string Direction { get; set; }

        public string Digit { get; set; }

        public bool Begin { get; set; }

        public bool End { get; set; }
    }
}