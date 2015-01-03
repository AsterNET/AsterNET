namespace AsterNET.Manager.Action
{
    public class QueueReloadAction : ManagerAction
    {
        /// <summary>
        ///     Reload a queue, queues, or any sub-section of a queue or queues.
        /// </summary>
        public QueueReloadAction()
        {
        }

        /// <summary>
        ///     Reload a queue, queues, or any sub-section of a queue or queues.
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

        public override string Action
        {
            get { return "QueueReload"; }
        }

        public string Queue { get; set; }

        public string Members { get; set; }

        public string Rules { get; set; }

        public string Parameters { get; set; }
    }
}