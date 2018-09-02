namespace AsterNET.Manager.Event
{

    /// <summary>
    ///     Raised when a device state changes.<br />
    ///     This differs from the ExtensionStatus event because this event is raised for all device state changes, not only for changes that affect dialplan hints.
    /// </summary>
    public class DeviceStateChangeEvent : ManagerEvent
    {
        /// <summary>
        ///     Creates a new <see cref="DeviceStateChangeEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        /// <param name="source"></param>
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