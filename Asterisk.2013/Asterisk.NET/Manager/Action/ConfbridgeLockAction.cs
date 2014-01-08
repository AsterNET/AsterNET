using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsterNET.Manager.Action
{
    public class ConfbridgeLockAction : ManagerAction
    {
        public string Conference { get; set; }

        public override string Action
		{
            get { return "ConfbridgeLock"; }
		}

        /// <summary>
        /// Locks a specified conference.
        /// </summary>
        public ConfbridgeLockAction()
        { }

		/// <summary>
        /// Locks a specified conference.
		/// </summary>
		/// <param name="conference"></param>
        public ConfbridgeLockAction(string conference)
		{
            this.Conference = conference;
		}
    }
}
