namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     Reload a queue, queues, or any sub-section of a queue or queues.
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_QueueReload">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_QueueReload</see>
    /// </summary>
    public class QueueReloadAction : ManagerAction
    {
        /// <summary>
        ///     Creates a new empty <see cref="QueueReloadAction"/>.
        /// </summary>
        public QueueReloadAction()
        {
        }

        /// <summary>
        ///     Creates a new <see cref="QueueReloadAction"/>.
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="members"></param>
        /// <param name="rules"></param>
        /// <param name="parameters"></param>
        public QueueReloadAction(string queue, string members, string rules, string parameters)
        {
            Queue = queue;
            Members = members;
            Rules = rules;
            Parameters = parameters;
        }

        /// <summary>
        ///     Get the name of this action, i.e. "QueueReload".
        /// </summary>
        public override string Action
        {
            get { return "QueueReload"; }
        }

        /// <summary>
        /// Gets or sets the queue.
        /// </summary>
        public string Queue { get; set; }

        /// <summary>
        /// Gets or sets the members.
        /// </summary>
        public string Members { get; set; }

        /// <summary>
        /// Gets or sets the rules.
        /// </summary>
        public string Rules { get; set; }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        public string Parameters { get; set; }
    }
}