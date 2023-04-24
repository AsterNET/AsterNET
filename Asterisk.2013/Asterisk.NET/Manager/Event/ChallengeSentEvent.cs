namespace AsterNET.Manager.Event
{

    /// <summary>
    ///     Raised when an Asterisk service sends an authentication challenge to a request.<br />
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_ChallengeSent">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_ChallengeSent</see>
    /// </summary>
    public class ChallengeSentEvent : ManagerEvent
    {
        /// <summary>
        ///     Creates a new <see cref="ChallengeSentEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public ChallengeSentEvent(ManagerConnection source) : base(source)
        {
        }

        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        public string Status { get; set; }
    }
}