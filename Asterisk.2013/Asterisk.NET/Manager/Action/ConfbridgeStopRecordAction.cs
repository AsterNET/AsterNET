using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsterNET.Manager.Action
{
    public class ConfbridgeStopRecordAction : ManagerAction
    {
        public string Conference { get; set; }

        public override string Action
		{
            get { return "ConfbridgeStopRecord"; }
		}

        /// <summary>
        /// Stops recording a specified conference.
        /// </summary>
        public ConfbridgeStopRecordAction()
        { }

		/// <summary>
        /// Stops recording a specified conference.
		/// </summary>
		/// <param name="conference"></param>
        public ConfbridgeStopRecordAction(string conference)
		{
            this.Conference = conference;
		}
    }
}
