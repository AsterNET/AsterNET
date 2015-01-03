namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     AgiExecEvents are triggered when an AGI command is executed.<br />
    ///     For each command two events are triggered: one before excution ("Start") and one after execution ("End").
    /// </summary>
    public class AGIExecEvent : ManagerEvent
    {
        /// <summary>
        ///     Creates a new AGIExecEvent.
        /// </summary>
        public AGIExecEvent(ManagerConnection source)
            : base(source)
        {
        }

        public long CommandId { get; set; }

        public string Command { get; set; }

        public string SubEvent { get; set; }

        public string Result { get; set; }

        public int ResultCode { get; set; }
    }
}