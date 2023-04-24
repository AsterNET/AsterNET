namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     A ConnectEvent is triggered after successful login to the asterisk server.<br />
    ///     It is a pseudo event not directly related to an asterisk generated event.
    /// </summary>
    public class ConnectEvent : ConnectionStateEvent
    {
        /// <summary>
        ///     Creates a new <see cref="ConnectEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public ConnectEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        ///     Get/Set the version of the protocol.
        /// </summary>
        public string ProtocolIdentifier { get; set; }
    }
}