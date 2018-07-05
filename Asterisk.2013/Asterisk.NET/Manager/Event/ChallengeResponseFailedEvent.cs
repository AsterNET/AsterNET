namespace AsterNET.Manager.Event
{

    /// <summary>
    ///     Raised when a request's attempt to authenticate has been challenged, and the request failed the authentication challenge.<br />
    /// </summary>
    public class ChallengeResponseFailedEvent : ManagerEvent
{
    public ChallengeResponseFailedEvent(ManagerConnection source)
        : base(source)
    {
    }

        public string Status { get; set; }
    }
}
