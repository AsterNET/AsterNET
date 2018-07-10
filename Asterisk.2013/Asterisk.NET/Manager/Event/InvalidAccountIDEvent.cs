namespace AsterNET.Manager.Event
{

    /// <summary>
    ///     Raised when a request fails an authentication check due to an invalid account ID.<br />
    /// </summary>
    public class InvalidAccountIDEvent : ManagerEvent
    {
        public InvalidAccountIDEvent(ManagerConnection source)
            : base(source)
        {
        }

        public string Status { get; set; }
    }
}