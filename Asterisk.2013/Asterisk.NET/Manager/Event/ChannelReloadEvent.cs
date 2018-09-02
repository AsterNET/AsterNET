namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     A ChannelReloadEvent is when a channel driver is reloaded, either on startup or by request.<br/>
    ///     For example, <code>channels/chan_sip.c</code> triggers the channel reload event when the SIP configuration 
    ///     is reloaded from sip.conf because the 'sip reload' command was issued at the Manager interface, the CLI, or for another reason.<br/>
    ///     Available since Asterisk 1.4.<br/>
    ///     It is implemented in <code>channels/chan_sip.c</code>
    /// </summary>
    public class ChannelReloadEvent : ManagerEvent
    {
        /// <summary>
        ///     Creates a new <see cref="ChannelReloadEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public ChannelReloadEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        ///     For SIP peers this is "SIP".
        /// </summary>
        public string ChannelType { get; set; }

        /// <summary>
        ///     Get/Set the name of the channel.
        /// </summary>
        public string ReloadReason { get; set; }

        /// <summary>
        ///     Gets or sets the user count.
        /// </summary>
        public int UserCount { get; set; }

        /// <summary>
        ///     Gets or sets the peer count.
        /// </summary>
        public int PeerCount { get; set; }

        /// <summary>
        ///     Gets or sets the registry count.
        /// </summary>
        public int RegistryCount { get; set; }
    }
}