namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Raised when all dynamic modules have finished their initial loading.<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+11+ManagerEvent_ModuleLoadReport">https://wiki.asterisk.org/wiki/display/AST/Asterisk+11+ManagerEvent_ModuleLoadReport</see>
    /// </summary>
    public class ModuleLoadReportEvent : ManagerEvent
    {
        /// <summary>
        ///     Creates a new <see cref="ModuleLoadReportEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public ModuleLoadReportEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        ///     Gets or sets the module load status.
        /// </summary>
        public string ModuleLoadStatus { get; set; }

        /// <summary>
        ///     Gets or sets the module selection.
        /// </summary>
        public string ModuleSelection { get; set; }

        /// <summary>
        ///     Gets or sets the module count.
        /// </summary>
        public int ModuleCount { get; set; }
    }
}