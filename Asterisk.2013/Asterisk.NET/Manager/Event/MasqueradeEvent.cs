namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Raised when a masquerade occurs between two channels, wherein the Clone channel's internal information replaces the Original channel's information.<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+11+ManagerEvent_Masquerade">https://wiki.asterisk.org/wiki/display/AST/Asterisk+11+ManagerEvent_Masquerade</see>
    /// </summary>
    /// <seealso cref="AsterNET.Manager.Event.ManagerEvent" />
    internal class MasqueradeEvent : ManagerEvent
    {
        /// <summary>
        ///     Gets or sets the clone.
        /// </summary>
        public string Clone { get; set; }

        /// <summary>
        ///     Gets or sets the state of the clone.
        /// </summary>
        public string CloneState { get; set; }

        /// <summary>
        ///     Gets or sets the original.
        /// </summary>
        public string Original { get; set; }

        /// <summary>
        ///     Gets or sets the state of the original.
        /// </summary>
        public string OriginalState { get; set; }

        #region Constructor - MasqueradeEvent(ManagerConnection source)

        /// <summary>
        ///     Creates a new <see cref="MasqueradeEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        /// <param name="source"></param>
        public MasqueradeEvent(ManagerConnection source)
            : base(source)
        {
        }

        #endregion
    }
}