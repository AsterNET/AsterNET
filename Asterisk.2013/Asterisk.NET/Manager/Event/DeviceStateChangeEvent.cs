namespace AsterNET.Manager.Event
{

    /// <summary>
    ///     Raised when a device state changes.<br />
    ///     This differs from the ExtensionStatus event because this event is raised for all device state changes, not only for changes that affect dialplan hints.
    /// </summary>
    public class DeviceStateChangeEvent : ManagerEvent
    {
        public DeviceStateChangeEvent(ManagerConnection source)
            : base(source)
        {
        }

        public string Status { get; set; }
    }
}