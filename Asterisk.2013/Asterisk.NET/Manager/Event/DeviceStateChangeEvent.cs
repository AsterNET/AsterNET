namespace AsterNET.Manager.Event
{

    /// <summary>
    ///     Raised when a device state changes.<br />
    ///     This differs from the ExtensionStatus event because this event is raised for all device state changes, not only for changes that affect dialplan hints.<br/>
    ///     <see target="_blank" href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_DeviceStateChange">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_DeviceStateChange</see>
    /// </summary>
    public class DeviceStateChangeEvent : ManagerEvent
    {
        /// <summary>
        ///     Creates a new <see cref="DeviceStateChangeEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public DeviceStateChangeEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        public string Status { get; set; }
    }
}