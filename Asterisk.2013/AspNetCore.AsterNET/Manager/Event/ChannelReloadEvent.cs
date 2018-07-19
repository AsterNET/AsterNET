namespace AspNetCore.AsterNET.Manager.Event
{
    public class ChannelReloadEvent : ManagerEvent
    {
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

        public int UserCount { get; set; }

        public int PeerCount { get; set; }

        public int RegistryCount { get; set; }
    }
}