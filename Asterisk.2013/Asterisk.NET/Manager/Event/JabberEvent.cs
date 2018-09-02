namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     
    /// </summary>
    public class JabberEvent : ManagerEvent
    {
        /// <summary>
        ///     Gets or sets the account.
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        ///     Gets or sets the packet.
        /// </summary>
        public string Packet { get; set; }

        #region Constructor - JabberEvent(ManagerConnection source)

        /// <summary>
        ///     Creates a new <see cref="JabberEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        /// <param name="source"></param>
        public JabberEvent(ManagerConnection source)
            : base(source)
        {
        }

        #endregion
    }
}