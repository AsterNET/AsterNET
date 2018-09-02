namespace AsterNET.Manager.Event
{

    /// <summary>
    ///     Raised when a request fails an authentication check due to an invalid account ID.<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_InvalidAccountID">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_InvalidAccountID</see>
    /// </summary>
    public class InvalidAccountIDEvent : ManagerEvent
    {
        /// <summary>
        ///     Creates a new <see cref="InvalidAccountIDEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        /// <param name="source"></param>
        public InvalidAccountIDEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        public string Status { get; set; }
    }
}