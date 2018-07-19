using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspNetCore.AsterNET.Manager.Event
{
    public class BridgeDestroyEvent : BridgeStateEvent
    {
        public BridgeDestroyEvent(ManagerConnection source) : base(source)
        {
        }
    }
}
