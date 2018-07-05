namespace AsterNET.Manager.Event
{

    /// <summary>
    ///     Raised when an Asterisk service sends an authentication challenge to a request..<br />
    /// </summary>
    public class ChallengeSentEvent : ManagerEvent
    {
        public ChallengeSentEvent(ManagerConnection source)
            : base(source)
        {
        }

        public string Status { get; set; }
    }
}