using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Raised when a conference participant has started or stopped talking.<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+11+ManagerEvent_ConfbridgeTalking">https://wiki.asterisk.org/wiki/display/AST/Asterisk+11+ManagerEvent_ConfbridgeTalking</see>
    /// </summary>
    public class ConfbridgeTalkingEvent : AbstractConfbridgeEvent
    {
        /// <summary>
        ///     Gets or sets the talking status.
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
