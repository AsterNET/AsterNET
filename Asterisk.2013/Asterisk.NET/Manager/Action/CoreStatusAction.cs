using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsterNET.Manager.Action
{
    public class CoreStatusAction : ManagerAction
    {
        /// <summary>
        /// Show PBX core status variables. Query for Core PBX status.
        /// </summary>
        public CoreStatusAction()
        {
        }

        public override string Action
        {
            get { return "CoreStatus"; }
        }
    }
}
