﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.AsterNET.Manager.Event
{
    public class ConfbridgeJoinEvent : AbstractConfbridgeEvent
    {
        /// <summary>
        /// 
        /// </summary>
        public string CallerIDnum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CallerIDname { get; set; }

        public ConfbridgeJoinEvent(ManagerConnection source)
			: base(source)
		{
		}
    }
}
