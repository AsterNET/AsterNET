using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsterNET.Manager.Event
{
    public class AbstractConfbridgeEvent : ManagerEvent
    {
        /// <summary>
        /// 
        /// </summary>
        public string Conference { get; set; }

        public AbstractConfbridgeEvent()
        : base()
        { }

        public AbstractConfbridgeEvent(ManagerConnection source)
			: base(source)
		{
		}
    }
}
