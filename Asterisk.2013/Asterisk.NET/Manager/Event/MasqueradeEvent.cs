namespace AsterNET.Manager.Event
{
    internal class MasqueradeEvent : ManagerEvent
    {
        public string Clone { get; set; }

        public string CloneState { get; set; }

        public string Original { get; set; }

        public string OriginalState { get; set; }

        #region Constructor - MasqueradeEvent(ManagerConnection source)

        public MasqueradeEvent(ManagerConnection source)
            : base(source)
        {
        }

        #endregion
    }
}