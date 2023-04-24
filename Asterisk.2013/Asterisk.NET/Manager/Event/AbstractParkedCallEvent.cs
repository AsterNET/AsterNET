namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Abstract base class for several call parking related events.
    /// </summary>
    public abstract class AbstractParkedCallEvent : ManagerEvent
    {
        /// <summary>
        ///     Creates a new <see cref="AbstractParkedCallEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public AbstractParkedCallEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        ///     Get/Set the extension the channel is or was parked at.
        /// </summary>
        public string Exten { get; set; }

        /// <summary>
        ///     Get/Set the Caller*ID number of the parked channel.
        /// </summary>
        public string CallerId { get; set; }

        /// <summary>
        ///     Get/Set the Caller*ID number of the parked channel.
        /// </summary>
        public string CallerIdNum { get; set; }

        /// <summary>
        ///     Get/Set the Caller*ID name of the parked channel.
        /// </summary>
        public string CallerIdName { get; set; }
    }
}