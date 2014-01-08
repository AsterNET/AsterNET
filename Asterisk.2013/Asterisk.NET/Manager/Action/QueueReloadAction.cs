using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsterNET.Manager.Action
{
    public class QueueReloadAction : ManagerAction
    {

        private string _queue;
        private string _members;
        private string _rules;
        private string _parameters;

        /// <summary>
        /// Reload a queue, queues, or any sub-section of a queue or queues.
        /// </summary>
        public QueueReloadAction()
        {
        }

        /// <summary>
        /// Reload a queue, queues, or any sub-section of a queue or queues.
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="members"></param>
        /// <param name="rules"></param>
        /// <param name="parameters"></param>
        public QueueReloadAction(string queue, string members, string rules, string parameters)
        {
            _queue = queue;
            _members = members;
            _rules = rules;
            _parameters = parameters;
        }

        public override string Action
        {
            get { return "QueueReload"; }
        }

        public string Queue
        {
            get { return _queue; }
            set { _queue = value; }
        }

        public string Members
        {
            get { return _members; }
            set { _members = value; }
        }

        public string Rules
        {
            get { return _rules; }
            set { _rules = value; }
        }

        public string Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
