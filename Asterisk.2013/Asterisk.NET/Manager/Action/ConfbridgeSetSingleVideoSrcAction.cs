using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsterNET.Manager.Action
{
    public class ConfbridgeSetSingleVideoSrcAction : ManagerAction
    {
        public string Conference { get; set; }
        public string Channel { get; set; }

        public override string Action
		{
            get { return "ConfbridgeSetSingleVideoSrc"; }
		}

        /// <summary>
        /// Stops recording a specified conference.
        /// </summary>
        public ConfbridgeSetSingleVideoSrcAction()
        { }

		/// <summary>
        /// Stops recording a specified conference.
		/// </summary>
		/// <param name="conference"></param>
        public ConfbridgeSetSingleVideoSrcAction(string conference, string channel)
		{
            this.Conference = conference;
            this.Channel = channel;
		}
    }
}
