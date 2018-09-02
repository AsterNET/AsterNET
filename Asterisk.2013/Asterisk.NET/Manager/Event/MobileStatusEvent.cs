namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     chan_mobile.so must be loaded either by loading it using the Asterisk CLI, or by adding it to /etc/asterisk/modules.conf 
    /// </summary>
    public class MobileStatusEvent : ManagerEvent
    {
        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        ///     Gets or sets the device.
        /// </summary>
        public string Device { get; set; }

        #region Constructor - MobileStatus(ManagerConnection source)

        /// <summary>
        ///     Creates a new <see cref="MobileStatusEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public MobileStatusEvent(ManagerConnection source)
            : base(source)
        {
        }

        #endregion
    }
}