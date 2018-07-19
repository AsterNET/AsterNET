namespace AspNetCore.AsterNET.Manager.Action
{
    public class QueueResetAction : ManagerAction
    {
        /// <summary>
        ///     Reset queue statistics.
        /// </summary>
        public QueueResetAction()
        {
        }

        /// <summary>
        ///     Reset queue statistics.
        /// </summary>
        /// <param name="queue"></param>
        public QueueResetAction(string queue)
        {
            Queue = queue;
        }

        public override string Action
        {
            get { return "QueueReset"; }
        }

        public string Queue { get; set; }
    }
}