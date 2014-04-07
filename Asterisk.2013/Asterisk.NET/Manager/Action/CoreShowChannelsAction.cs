using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsterNET.Manager.Action
{
    public class CoreShowChannelsAction : ManagerAction
    {
        /// <summary>
        /// List currently defined channels and some information about them.
        /// </summary>
        public CoreShowChannelsAction()
        {
        }

        public override string Action
        {
            get { return "CoreShowChannels"; }
        }
    }
}
