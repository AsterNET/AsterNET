using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     
    /// 
    ///     See <see target="_blank"  href=""></see>
    /// </summary>
    /// <seealso cref="ConfbridgeListRoomsEvent" />
    public class ConfbridgeListRoomsCompleteEvent : ResponseEvent
    {
        /// <summary>
        ///     Creates a new <see cref="ConfbridgeListRoomsCompleteEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public ConfbridgeListRoomsCompleteEvent(ManagerConnection source)
			: base(source)
		{
		}
    }
}
