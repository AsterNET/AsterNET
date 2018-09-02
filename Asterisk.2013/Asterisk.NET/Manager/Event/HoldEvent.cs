namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     A HoldEvent is triggered by the SIP channel driver when a channel is put on hold.<br />
    ///     It is implemented in channels/chan_sip.c.<br />
    ///     Available since Asterisk 1.2<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_Hold">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_Hold</see>
    /// </summary>
    /// <seealso cref="Manager.Event.UnholdEvent" />
    public class HoldEvent : ManagerEvent
    {
        /// <summary>
        ///     Creates a new <see cref="HoldEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public HoldEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        public string Status { get; set; }
    }
}