using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsterNET.Manager.Event
{
    public class BridgeLeaveEvent : BridgeActivityEvent
    {
        public BridgeLeaveEvent(ManagerConnection source) : base(source)
        {
        }
    }
}
