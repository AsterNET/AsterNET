namespace AsterNET.Manager.Action
{
    public class QueuePenaltyAction : ManagerAction
    {
        /// <summary>
        ///     Set the penalty for a queue member.
        /// </summary>
        public QueuePenaltyAction()
        {
        }

        /// <summary>
        ///     Set the penalty for a queue member.
        /// </summary>
        /// <param name="interface"></param>
        /// <param name="penalty"></param>
        /// <param name="queue"></param>
        public QueuePenaltyAction(string @interface, string penalty, string queue)
        {
            Interface = @interface;
            Penalty = penalty;
            Queue = queue;
        }

        public override string Action
        {
            get { return "QueuePenalty"; }
        }

        public string Interface { get; set; }

        public string Penalty { get; set; }

        public string Queue { get; set; }
    }
}