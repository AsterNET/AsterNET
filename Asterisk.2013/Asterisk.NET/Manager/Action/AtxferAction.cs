using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsterNET.Manager.Action
{
    public class AtxferAction : ManagerAction
    {

        private string _channel;
        private string _exten;
        private string _context;
        private string _priority;

        /// <summary>
        /// Attended transfer.
        /// </summary>
        public AtxferAction()
        {
        }

        /// <summary>
        /// Attended transfer.
        /// </summary>
        /// <param name="channel">Transferer's channel.</param>
        /// <param name="exten">Extension to transfer to.</param>
        /// <param name="context">Context to transfer to.</param>
        /// <param name="priority">Priority to transfer to.</param>
        public AtxferAction(string channel, string exten, string context, string priority)
        {
            _channel = channel;
            _exten = exten;
            _context = context;
            _priority = priority;
        }

        public override string Action
        {
            get { return "Atxfer"; }
        }

        /// <summary>
        /// Transferer's channel.
        /// </summary>
        public string Channel
        {
            get { return _channel; }
            set { _channel = value; }
        }

        /// <summary>
        /// Extension to transfer to.
        /// </summary>
        public string Exten
        {
            get { return _exten; }
            set { _exten = value; }
        }

        /// <summary>
        /// Context to transfer to.
        /// </summary>
        public string Context
        {
            get { return _context; }
            set { _context = value; }
        }

        /// <summary>
        /// Priority to transfer to.
        /// </summary>
        public string Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }
    }
}
