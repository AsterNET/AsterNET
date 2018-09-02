using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     
    /// </summary>
    public class ConfbridgeTalkingEvent : AbstractConfbridgeEvent
    {
        /// <summary>
        /// 
        /// </summary>
        public string TalkingStatus { get; set; }

        /// <summary>
        ///     Creates a new <see cref="ConfbridgeTalkingEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        /// <param name="source"></param>
        public ConfbridgeTalkingEvent(ManagerConnection source)
			: base(source)
		{
		}
    }
}
