using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsterNET.Manager.Action
{
    public class QueuePenaltyAction : ManagerAction
    {

        private string _interface;
        private string _penalty;
        private string _queue;

        /// <summary>
        /// Set the penalty for a queue member.
        /// </summary>
        public QueuePenaltyAction()
        {
        }

        /// <summary>
        /// Set the penalty for a queue member.
        /// </summary>
        /// <param name="interface"></param>
        /// <param name="penalty"></param>
        /// <param name="queue"></param>
        public QueuePenaltyAction(string @interface, string penalty, string queue)
        {
            _interface = @interface;
            _penalty = penalty;
            _queue = queue;
        }

        public override string Action
        {
            get { return "QueuePenalty"; }
        }

        public string Interface
        {
            get { return _interface; }
            set { _interface = value; }
        }

        public string Penalty
        {
            get { return _penalty; }
            set { _penalty = value; }
        }

        public string Queue
        {
            get { return _queue; }
            set { _queue = value; }
        }
    }
}
