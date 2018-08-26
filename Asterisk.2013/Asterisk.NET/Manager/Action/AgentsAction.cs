using System;
using AsterNET.Manager.Event;

namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     The AgentsAction requests the state of all agents.<br />
    ///     For each agent an AgentsEvent is generated.
    ///     After the state of all agents has been reported an AgentsCompleteEvent is generated.<br />
    ///     Available since Asterisk 1.2
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_Agents">Asterisk Documentation</see>
    /// </summary>
    /// <seealso cref="AsterNET.Manager.Event.AgentsEvent" />
    /// <seealso cref="AsterNET.Manager.Event.AgentsCompleteEvent" />
    public class AgentsAction : ManagerActionEvent
    {
        #region Action 

        /// <summary>
        ///     Get the name of this action, i.e. "Agents".
        /// </summary>
        public override string Action
        {
            get { return "Agents"; }
        }

        #endregion

        #region ActionCompleteEventClass 

        public override Type ActionCompleteEventClass()
        {
            return typeof (AgentsCompleteEvent);
        }

        #endregion

        #region AgentsAction() 

        #endregion
    }
}