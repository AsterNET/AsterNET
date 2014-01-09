using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsterNET.Manager.Event
{
    public class ConfbridgeEndEvent : AbstractConfbridgeEvent
    {
        public ConfbridgeEndEvent(ManagerConnection source)
			: base(source)
		{
		}
    }
}
