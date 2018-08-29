using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Raised when a channel leaves a Confbridge conference.
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_ConfbridgeLeave">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_ConfbridgeLeave</see>
    /// </summary>
    public class ConfbridgeLeaveEvent : AbstractConfbridgeEvent
    {
        /// <summary>
        ///     Gets or sets the Caller*ID number.
        /// </summary>
        public string CallerIDnum { get; set; }

        /// <summary>
        ///     Gets or sets the Caller*ID name.
        /// </summary>
        public string CallerIDname { get; set; }

        /// <summary>
        ///     Creates a new <see cref="ConfbridgeLeaveEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        /// <param name="source"></param>
        public ConfbridgeLeaveEvent(ManagerConnection source)
			: base(source)
		{
		}
    }
}
