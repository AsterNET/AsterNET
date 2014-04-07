using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsterNET.Manager.Action
{
    public class CoreSettingsAction : ManagerAction
    {
        /// <summary>
        /// Show PBX core settings (version etc).
        /// </summary>
        public CoreSettingsAction()
        {
        }

        public override string Action
        {
            get { return "CoreSettings"; }
        }
    }
}
