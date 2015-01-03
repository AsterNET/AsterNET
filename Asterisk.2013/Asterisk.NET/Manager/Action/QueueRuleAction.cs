namespace AsterNET.Manager.Action
{
    public class QueueRuleAction : ManagerAction
    {
        public QueueRuleAction()
        {
        }

        public QueueRuleAction(string rule)
        {
            Rule = rule;
        }

        public override string Action
        {
            get { return "QueueRule"; }
        }

        public string Rule { get; set; }
    }
}