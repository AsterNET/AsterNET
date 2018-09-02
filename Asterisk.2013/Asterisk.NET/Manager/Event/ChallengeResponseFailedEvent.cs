namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Raised when a request's attempt to authenticate has been challenged, and the request failed the authentication challenge.<br />
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_ChallengeResponseFailed">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_ChallengeResponseFailed</see>
    /// </summary>
    public class ChallengeResponseFailedEvent : ManagerEvent
    {
        /// <summary>
        ///     Creates a new <see cref="ChallengeResponseFailedEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        /// <param name="source"></param>
        public ChallengeResponseFailedEvent(ManagerConnection source) : base(source)
        {
        }

        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        public string Status { get; set; }
    }
}
