namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     A DBGetResponseEvent is sent in response to a DBGetAction and contains the entry that was queried.<br />
    ///     Available since Asterisk 1.2
    /// </summary>
    /// <seealso cref="Manager.Action.DBGetAction" />
    public class DBGetResponseEvent : ResponseEvent
    {
        /// <summary>
        ///     Creates a new <see cref="DBGetResponseEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public DBGetResponseEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        ///     Get/Set the family of the database entry that was queried.
        /// </summary>
        public string Family { get; set; }

        /// <summary>
        ///     Get/Set the key of the database entry that was queried.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        ///     Get/Set the value of the database entry that was queried.
        /// </summary>
        public string Val { get; set; }
    }
}