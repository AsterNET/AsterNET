using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Abstract base class providing common properties for Conference Bridge Events.
    /// </summary>
    /// <seealso cref="AsterNET.Manager.Event.ManagerEvent" />
    public class AbstractConfbridgeEvent : ManagerEvent
    {
        /// <summary>
        /// <b>Available since : </b> <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+10+Documentation" target="_blank" alt="Asterisk 10 wiki docs">Asterisk 10</see>.
        /// </summary>
        public string Conference { get; set; }

        /// <summary>
        ///     Creates a new empty <see cref="AbstractConfbridgeEvent"/>.
        /// </summary>
        public AbstractConfbridgeEvent()
        : base()
        { }

        /// <summary>
        ///     Creates a new <see cref="AbstractConfbridgeEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        /// <param name="source"></param>
        public AbstractConfbridgeEvent(ManagerConnection source)
			: base(source)
		{
		}
    }
}
