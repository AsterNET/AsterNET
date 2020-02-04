using System;
using AsterNET.Manager.Event;

namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     The ParkedCallsAction requests a list of all currently parked calls.<br />
    ///     For each active channel a ParkedCallEvent is generated. After all parked
    ///     calls have been reported a ParkedCallsCompleteEvent is generated.
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_ParkedCalls">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_ParkedCalls</see>
    /// </summary>
    /// <seealso cref="AsterNET.Manager.Event.ParkedCallEvent" />
    /// <seealso cref="AsterNET.Manager.Event.ParkedCallsCompleteEvent" />
    public class ParkedCallsAction : ManagerActionEvent
    {
        /// <summary> Get the name of this action, i.e. "ParkedCalls".</summary>
        public override string Action
        {
            get { return "ParkedCalls"; }
        }

        public override Type ActionCompleteEventClass()
        {
            return typeof (ParkedCallsCompleteEvent);
        }
    }
}