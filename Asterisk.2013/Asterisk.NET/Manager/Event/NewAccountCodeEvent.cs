namespace AsterNET.Manager.Event
{
    public class NewAccountCodeEvent : ManagerEvent
    {
        public NewAccountCodeEvent(ManagerConnection source)
            : base(source)
        {
        }

        public string AccountCode { get; set; }

        public string OldAccountCode { get; set; }
    }
}