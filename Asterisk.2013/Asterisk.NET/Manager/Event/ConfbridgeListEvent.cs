using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsterNET.Manager.Event
{
    public class ConfbridgeListEvent : ResponseEvent
    {
        /// <summary>
        /// 
        /// </summary>
        public string Conference { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CallerIDNum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CallerIDName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Admin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string MarkedUser { get; set; }

        public ConfbridgeListEvent(ManagerConnection source)
			: base(source)
		{
		}
    }
}
