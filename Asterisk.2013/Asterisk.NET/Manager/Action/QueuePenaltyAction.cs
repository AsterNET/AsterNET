namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     Set the penalty for a queue member.
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_QueuePenalty">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_QueuePenalty</see>
    /// </summary>
    public class QueuePenaltyAction : ManagerAction
    {
        /// <summary>
        ///     Creates a new empty <see cref="QueuePenaltyAction"/>.
        /// </summary>
        public QueuePenaltyAction()
        {
        }

        /// <summary>
        ///     Creates a new <see cref="QueuePenaltyAction"/>.
        /// </summary>
        /// <param name="interface">The interface (tech/name) of the member whose penalty to change.</param>
        /// <param name="penalty">The new penalty (number) for the member. Must be nonnegative.</param>
        public QueuePenaltyAction(string @interface, string penalty)
        {
            Interface = @interface;
            Penalty = penalty;
        }

        /// <summary>
        ///     Creates a new <see cref="QueuePenaltyAction"/>.
        /// </summary>
        /// <param name="interface">The interface (tech/name) of the member whose penalty to change.</param>
        /// <param name="penalty">The new penalty (number) for the member. Must be nonnegative.</param>
        /// <param name="queue">If specified, only set the penalty for the member of this queue. Otherwise, set the penalty for the member in all queues to which the member belongs.</param>
        public QueuePenaltyAction(string @interface, string penalty, string queue)
        {
            Interface = @interface;
            Penalty = penalty;
            Queue = queue;
        }

        /// <summary>
        ///     Get the name of this action, i.e. "QueuePenalty".
        /// </summary>
        public override string Action
        {
            get { return "QueuePenalty"; }
        }
        
        /// <summary>
        /// The interface (tech/name) of the member whose penalty to change.
        /// </summary>
        public string Interface { get; set; }
        
        /// <summary>
        /// The new penalty (number) for the member. Must be nonnegative.
        /// </summary>
        public string Penalty { get; set; }
        
        /// <summary>
        /// If specified, only set the penalty for the member of this queue. Otherwise, set the penalty for the member in all queues to which the member belongs.
        /// </summary>
        public string Queue { get; set; }
    }
}
