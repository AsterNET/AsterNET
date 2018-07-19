namespace AspNetCore.AsterNET.Manager.Event
{
    /// <summary>
    ///     A HoldEvent is triggered by the SIP channel driver when a channel is put on hold.<br />
    ///     It is implemented in channels/chan_sip.c.<br />
    ///     Available since Asterisk 1.2
    /// </summary>
    /// <seealso cref="Manager.Event.UnholdEvent" />
    public class HoldEvent : ManagerEvent
    {
        public HoldEvent(ManagerConnection source)
            : base(source)
        {
        }

        public string Status { get; set; }
    }
}