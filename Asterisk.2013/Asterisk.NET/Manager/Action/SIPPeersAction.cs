using System;
using AsterNET.Manager.Event;

namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     Retrieves a list of all defined SIP peers.<br />
    ///     For each peer that is found a PeerEntryEvent is sent by Asterisk containing
    ///     the details. When all peers have been reported a PeerlistCompleteEvent is sent.<br />
    ///     Available since Asterisk 1.2
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_SIPpeers">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_SIPpeers</see>
    /// </summary>
    /// <seealso cref="Manager.Event.PeerEntryEvent" />
    /// <seealso cref="Manager.Event.PeerlistCompleteEvent" />
    public class SIPPeersAction : ManagerActionEvent
    {
        /// <summary>
        ///     Get the name of the action, i.e. "SIPPeers".
        /// </summary>
        public override string Action
        {
            get { return "SIPPeers"; }
        }

        public override Type ActionCompleteEventClass()
        {
            return typeof (PeerlistCompleteEvent);
        }
    }
}