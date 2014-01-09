using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsterNET.Manager.Event
{
    public class ConfbridgeStartEvent : AbstractConfbridgeEvent
    {
        public ConfbridgeStartEvent(ManagerConnection source)
			: base(source)
		{
		}
    }
}
