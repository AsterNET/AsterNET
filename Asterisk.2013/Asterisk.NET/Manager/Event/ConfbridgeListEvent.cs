using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Lists all users in a particular ConfBridge conference. ConfbridgeList will follow as separate events, followed by a final event called ConfbridgeListComplete<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/ConfBridge+AMI+Actions#ConfBridgeAMIActions-ConfbridgeList">https://wiki.asterisk.org/wiki/display/AST/ConfBridge+AMI+Actions#ConfBridgeAMIActions-ConfbridgeList</see>
    /// </summary>
    public class ConfbridgeListEvent : AbstractConfbridgeEvent
    {

        /// <summary>
        ///     Gets or sets the caller identifier number.
        /// </summary>
        public string CallerIDNum { get; set; }

        /// <summary>
        ///     Gets or sets the name of the caller identifier.
        /// </summary>
        public string CallerIDName { get; set; }

        /// <summary>
        ///     Gets or sets the admin.
        /// </summary>
        public string Admin { get; set; }

        /// <summary>
        ///     Gets or sets the marked user.
        /// </summary>
        public string MarkedUser { get; set; }

        /// <summary>
        ///     Creates a new <see cref="ConfbridgeListEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        /// <param name="source"></param>
        public ConfbridgeListEvent(ManagerConnection source)
			: base(source)
		{
		}
    }
}
