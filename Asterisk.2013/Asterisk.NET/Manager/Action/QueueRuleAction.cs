using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsterNET.Manager.Action
{
    public class QueueRuleAction : ManagerAction
    {

        private string _rule;

        public QueueRuleAction()
        {
        }

        public QueueRuleAction(string rule)
        {
            _rule = rule;
        }

        public override string Action
        {
            get { return "QueueRule"; }
        }

        public string Rule
        {
            get { return _rule; }
            set { _rule = value; }
        }
    }
}
