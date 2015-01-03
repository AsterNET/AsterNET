namespace AsterNET.Manager.Event
{
    public class AsyncAGIEvent : ManagerEvent
    {
        public string Result { get; set; }

        public string CommandId { get; set; }

        public string SubEvent { get; set; }

        public string Env { get; set; }

        #region Constructor - AsyncAGIEvent(ManagerConnection source)

        public AsyncAGIEvent(ManagerConnection source)
            : base(source)
        {
        }

        #endregion
    }
}