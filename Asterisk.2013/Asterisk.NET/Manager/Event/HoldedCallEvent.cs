namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     A HoldedCallEvent is triggered when a channel is put on hold.<br/>
    ///     It is implemented in res/res_features.c
    /// </summary>
    public class HoldedCallEvent : ManagerEvent
    {
        /// <summary>
        ///     Creates a new <see cref="HoldedCallEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        /// <param name="source"></param>
        public HoldedCallEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        ///     Get/Set the unique id of the channel that put the other channel on hold.
        /// </summary>
        public string UniqueId1 { get; set; }

        /// <summary>
        ///     Get/Set the unique id of the channel that has been put on hold.
        /// </summary>
        public string UniqueId2 { get; set; }

        /// <summary>
        ///     Get/Set the name of the channel that put the other channel on hold.
        /// </summary>
        public string Channel1 { get; set; }

        /// <summary>
        ///     Get/Set the name of the channel that has been put on hold.
        /// </summary>
        public string Channel2 { get; set; }
    }
}