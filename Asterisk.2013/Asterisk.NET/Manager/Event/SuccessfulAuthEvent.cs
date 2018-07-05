namespace AsterNET.Manager.Event
{

    /// <summary>
    ///     Raised when a request successfully authenticates with a service..<br />
    /// </summary>
    public class SuccessfulAuthEvent : ManagerEvent
    {
        public SuccessfulAuthEvent(ManagerConnection source)
            : base(source)
        {
        }

        public string Status { get; set; }
    }
}