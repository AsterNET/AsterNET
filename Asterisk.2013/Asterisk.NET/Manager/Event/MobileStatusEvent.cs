namespace AsterNET.Manager.Event
{
    public class MobileStatusEvent : ManagerEvent
    {
        public string Status { get; set; }

        public string Device { get; set; }

        #region Constructor - MobileStatus(ManagerConnection source)

        public MobileStatusEvent(ManagerConnection source)
            : base(source)
        {
        }

        #endregion
    }
}