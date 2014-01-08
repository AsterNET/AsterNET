using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsterNET.Manager.Action
{
    public class QueueResetAction : ManagerAction
    {

        private string _queue;

        /// <summary>
        /// Reset queue statistics.
        /// </summary>
        public QueueResetAction()
        {
        }

        /// <summary>
        /// Reset queue statistics.
        /// </summary>
        /// <param name="queue"></param>
        public QueueResetAction(string queue)
        {
            _queue = queue;
        }

        public override string Action
        {
            get { return "QueueReset"; }
        }

        public string Queue
        {
            get { return _queue; }
            set { _queue = value; }
        }
    }
}
