namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     A DNDStateEvent is triggered by the Zap channel driver when a channel enters or leaves DND (do not disturb) state.<br />
    ///     It is implemented in channels/chan_zap.c.<br />
    ///     Available since Asterisk 1.2<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_DNDState">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_DNDState</see>
    /// </summary>
    public class DNDStateEvent : ManagerEvent
    {
        /// <summary>
        ///     Creates a new <see cref="DNDStateEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        public DNDStateEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        ///     Get/Set DND state of the channel. "enabled" if do not disturb is on, "disabled" if it is off.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        ///     Get/Set DND state of the channel. "enabled" if do not disturb is on, "disabled" if it is off.
        /// </summary>
        public string Status { get; set; }
    }
}