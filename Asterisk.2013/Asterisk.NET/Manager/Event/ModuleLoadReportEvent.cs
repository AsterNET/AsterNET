namespace AsterNET.Manager.Event
{
    public class ModuleLoadReportEvent : ManagerEvent
    {
        public ModuleLoadReportEvent(ManagerConnection source)
            : base(source)
        {
        }

        public string ModuleLoadStatus { get; set; }

        public string ModuleSelection { get; set; }

        public int ModuleCount { get; set; }
    }
}