using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asterisk.NET.Manager.Action
{
    /// <summary>
    /// This action lets you execute any AGI command through the Manager interface
    /// For example, check the Asterisk.Net.Test project
    /// </summary>
    public class AgiAction : ManagerAction
    {
        public string Channel { get; set; }
        public string Command { get; set; }

        /// <summary>
        /// Get the name of this action, i.e. "AGI".
        /// </summary>
        override public string Action
        {
            get { return "AGI"; }
        }

        /// <summary>
        /// Creates a new empty AgiAction.
        /// </summary>
        public AgiAction(string channel, string command)
        {
            Channel = channel;
            Command = command;
        }


    }
}