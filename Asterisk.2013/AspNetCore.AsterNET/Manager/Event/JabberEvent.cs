namespace AspNetCore.AsterNET.Manager.Event
{
    public class JabberEvent : ManagerEvent
    {
        public string Account { get; set; }

        public string Packet { get; set; }

        #region Constructor - JabberEvent(ManagerConnection source)

        public JabberEvent(ManagerConnection source)
            : base(source)
        {
        }

        #endregion
    }
}