namespace AsterNET.Manager.Event
{
    /// <summary>
    /// 
    /// </summary>
    public class QueueSummaryEvent : ManagerEvent
    {
        public QueueSummaryEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        /// Queue name
        /// </summary>
        public string Queue { get; set; }

        /// <summary>
        /// Logged operators count in queue
        /// </summary>
        public int LoggedIn { get; set; }

        /// <summary>
        /// Available operators in queue
        /// </summary>
        public int Available { get; set; }

        /// <summary>
        /// Calls count
        /// </summary>
        public int Callers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int HoldTime { get; set; }

        /// <summary>
        /// Total talk time
        /// </summary>
        public int TalkTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int LongestHoldTime { get; set; }
    }
}
