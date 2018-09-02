namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Raised when a Channel's AccountCode is changed.<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_NewAccountCode">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_NewAccountCode</see>
    /// </summary>
    public class NewAccountCodeEvent : ManagerEvent
    {
        /// <summary>
        ///     Creates a new <see cref="NewAccountCodeEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public NewAccountCodeEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        ///     Gets or sets the account code.
        /// </summary>
        public string AccountCode { get; set; }

        /// <summary>
        ///     Gets or sets the old account code.
        /// </summary>
        public string OldAccountCode { get; set; }
    }
}