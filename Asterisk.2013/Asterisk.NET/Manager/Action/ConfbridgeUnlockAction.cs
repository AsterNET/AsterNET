using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsterNET.Manager.Action
{
    public class ConfbridgeUnlockAction : ManagerAction
    {
        public string Conference { get; set; }

        public override string Action
		{
            get { return "ConfbridgeUnlock"; }
		}

        /// <summary>
        /// Unlocks a specified conference.
        /// </summary>
        public ConfbridgeUnlockAction()
        { }

		/// <summary>
        /// Unlocks a specified conference.
		/// </summary>
		/// <param name="conference"></param>
        public ConfbridgeUnlockAction(string conference)
		{
            this.Conference = conference;
		}
    }
}
