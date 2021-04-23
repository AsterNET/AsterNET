using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsterNET.Manager.Event
{
    public class ConfbridgeMuteEvent : AbstractConfbridgeEvent
    {
        public ConfbridgeMuteEvent(ManagerConnection source)
            : base(source)
        {
        }
    }
}
