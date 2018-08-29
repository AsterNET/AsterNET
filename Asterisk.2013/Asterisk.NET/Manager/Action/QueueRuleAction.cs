namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     List queue rules defined in queuerules.conf
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_QueueRule">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_QueueRule</see>
    /// </summary>
    public class QueueRuleAction : ManagerAction
    {
        /// <summary>
        ///     Creates a new empty <see cref="QueueRuleAction"/>.
        /// </summary>
        public QueueRuleAction()
        {
        }

        /// <summary>
        ///     Creates a new <see cref="QueueRuleAction"/> using the given rule.
        /// </summary>
        public QueueRuleAction(string rule)
        {
            Rule = rule;
        }

        /// <summary>
        ///     Get the name of this action, i.e. "QueueReset".
        /// </summary>
        public override string Action
        {
            get { return "QueueRule"; }
        }

        /// <summary>
        ///     Gets or sets the rule.
        /// </summary>
        public string Rule { get; set; }
    }
}