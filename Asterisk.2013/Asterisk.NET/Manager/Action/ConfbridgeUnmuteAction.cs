using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asterisk.NET.Manager.Action
{
    public class ConfbridgeUnmuteAction : ManagerAction
    {
        public string Conference { get; set; }
        public string Channel { get; set; }

        public override string Action
		{
            get { return "ConfbridgeUnmute"; }
		}

        /// <summary>
        /// Unmutes a specified user in a specified conference.
        /// </summary>
        public ConfbridgeUnmuteAction()
        { }

		/// <summary>
        /// Unmutes a specified user in a specified conference.
		/// </summary>
		/// <param name="conference"></param>
		/// <param name="channel"></param>
        public ConfbridgeUnmuteAction(string conference, string channel)
		{
            this.Conference = conference;
            this.Channel = channel;
		}
    }
}
