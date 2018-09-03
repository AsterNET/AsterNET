using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Raised after all <see cref="ConfbridgeListEvent"/> are complete.<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/ConfBridge+AMI+Actions#ConfBridgeAMIActions-ConfbridgeList">https://wiki.asterisk.org/wiki/display/AST/ConfBridge+AMI+Actions#ConfBridgeAMIActions-ConfbridgeList</see>
    /// </summary>
    /// <seealso cref="Manager.Action.ConfbridgeListAction"/>
    /// <seealso cref="Manager.Event.ConfbridgeListEvent"/>
    public class ConfbridgeListCompleteEvent : ResponseEvent
    {
        /// <summary>
        ///     Creates a new <see cref="ConfbridgeListCompleteEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public ConfbridgeListCompleteEvent(ManagerConnection source)
			: base(source)
		{
		}
    }
}
