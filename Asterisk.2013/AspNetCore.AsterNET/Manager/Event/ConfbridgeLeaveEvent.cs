﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.AsterNET.Manager.Event
{
    public class ConfbridgeLeaveEvent : AbstractConfbridgeEvent
    {
        /// <summary>
        /// 
        /// </summary>
        public string CallerIDnum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CallerIDname { get; set; }

        public ConfbridgeLeaveEvent(ManagerConnection source)
			: base(source)
		{
		}
    }
}
