using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsterNET.Manager.Event
{
    public class BridgeCreateEvent : BridgeStateEvent
    {
        public BridgeCreateEvent(ManagerConnection source) : base(source)
        {
        }
    }
}
