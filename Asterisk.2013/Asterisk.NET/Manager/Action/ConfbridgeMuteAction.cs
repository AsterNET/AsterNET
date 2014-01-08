using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsterNET.Manager.Action
{
    public class ConfbridgeMuteAction : ManagerAction
    {
        public string Conference { get; set; }
        public string Channel { get; set; }

        public override string Action
		{
            get { return "ConfbridgeMute"; }
		}

        /// <summary>
        /// Mutes a specified user in a specified conference.
        /// </summary>
        public ConfbridgeMuteAction()
        { }

		/// <summary>
        /// Mutes a specified user in a specified conference.
		/// </summary>
		/// <param name="conference"></param>
		/// <param name="channel"></param>
        public ConfbridgeMuteAction(string conference, string channel)
		{
            this.Conference = conference;
            this.Channel = channel;
		}
    }
}
