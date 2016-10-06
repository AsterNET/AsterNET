namespace AsterNET.Manager.Event
{
    public class DTMFEndEvent : ManagerEvent
    {
        /// <summary>
        ///     Creates a new DialEvent.
        /// </summary>
        public DTMFEndEvent(ManagerConnection source)
            : base(source)
        {
        }

        public string Direction { get; set; }

        public string Digit { get; set; }
        
        public int DurationMs { get; set; }
    }
}