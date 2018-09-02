namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Raised when a DTMF digit has started/ended on a channel.<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+11+ManagerEvent_DTMF">https://wiki.asterisk.org/wiki/display/AST/Asterisk+11+ManagerEvent_DTMF</see>
    /// </summary>
    public class DTMFEvent : ManagerEvent
    {
        /// <summary>
        ///     Creates a new <see cref="DTMFEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        public DTMFEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        ///     Gets or sets the direction.
        /// </summary>
        public string Direction { get; set; }

        /// <summary>
        ///     Gets or sets the digit.
        /// </summary>
        public string Digit { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="DTMFEvent"/> is a DTMFBeginEvent.
        /// </summary>
        public bool Begin { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="DTMFEvent"/> is a DTMFEndEvent.
        /// </summary>
        public bool End { get; set; }
    }
}