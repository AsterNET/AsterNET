using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     An ConfbridgeListCompleteEvent is triggered after the state of all Confbridges has been
    ///     reported in response to an ConfbridgeListAction.
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/ConfBridge+AMI+Actions">https://wiki.asterisk.org/wiki/display/AST/ConfBridge+AMI+Actions</see>
    /// </summary>
    /// /// <seealso cref="ConfbridgeListEvent" />
    public class ConfbridgeListCompleteEvent : ResponseEvent
    {
        /// <summary>
        ///     Creates a new <see cref="ConfbridgeListCompleteEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        /// <param name="source"></param>
        public ConfbridgeListCompleteEvent(ManagerConnection source)
			: base(source)
		{
		}
    }
}

