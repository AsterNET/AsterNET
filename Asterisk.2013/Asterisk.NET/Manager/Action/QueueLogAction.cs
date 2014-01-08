using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsterNET.Manager.Action
{
    public class QueueLogAction : ManagerAction
    {

        private string _queue;
        private string _event;
        private string _uniqueid;
        private string _interface;
        private string _message;

        /// <summary>
        /// Adds custom entry in queue_log.
        /// </summary>
        public QueueLogAction()
        {
        }

        /// <summary>
        /// Adds custom entry in queue_log.
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="event"></param>
        /// <param name="uniqueid"></param>
        /// <param name="interface"></param>
        /// <param name="message"></param>
        public QueueLogAction(string queue, string @event, string uniqueid, string @interface, string message)
        {
            _queue = queue;
            _event = @event;
            _uniqueid = uniqueid;
            _interface = @interface;
            _message = message;
        }

        public override string Action
        {
            get { return "QueueLog"; }
        }

        public string Queue
        {
            get { return _queue; }
            set { _queue = value; }
        }

        public string Event
        {
            get { return _event; }
            set { _event = value; }
        }

        public string Uniqueid
        {
            get { return _uniqueid; }
            set { _uniqueid = value; }
        }

        public string Interface
        {
            get { return _interface; }
            set { _interface = value; }
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
    }
}
