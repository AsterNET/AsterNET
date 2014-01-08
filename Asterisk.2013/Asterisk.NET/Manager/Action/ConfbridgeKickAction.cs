using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsterNET.Manager.Action
{
    public class ConfbridgeKickAction : ManagerAction
    {
        public string Conference { get; set; }
        public string Channel { get; set; }

        public override string Action
		{
            get { return "ConfbridgeKick"; }
		}

        /// <summary>
        /// Removes a specified user from a specified conference.
        /// </summary>
        public ConfbridgeKickAction()
        { }

		/// <summary>
        /// Removes a specified user from a specified conference.
		/// </summary>
		/// <param name="conference"></param>
		/// <param name="channel"></param>
        public ConfbridgeKickAction(string conference, string channel)
		{
            this.Conference = conference;
            this.Channel = channel;
		}
    }
}
