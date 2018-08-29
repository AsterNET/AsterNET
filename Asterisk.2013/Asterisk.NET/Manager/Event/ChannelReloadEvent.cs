namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     
    /// </summary>
    public class ChannelReloadEvent : ManagerEvent
    {
        /// <summary>
        ///     Creates a new <see cref="ChannelReloadEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        /// <param name="source"></param>
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
        /// Gets or sets the user count.
        /// </summary>
        public int UserCount { get; set; }

        /// <summary>
        /// Gets or sets the peer count.
        /// </summary>
        public int PeerCount { get; set; }

        /// <summary>
        /// Gets or sets the registry count.
        /// </summary>
        public int RegistryCount { get; set; }
    }
}