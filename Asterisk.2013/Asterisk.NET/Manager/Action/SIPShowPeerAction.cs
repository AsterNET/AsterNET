using System;
using AsterNET.Manager.Event;

namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     Retrieves a the details about a given SIP peer.<br />
    ///     For a PeerEntryEvent is sent by Asterisk containing the details of the peer
    ///     followed by a PeerlistCompleteEvent.<br />
    ///     Available since Asterisk 1.2
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_SIPshowpeer">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_SIPshowpeer</see>
    /// </summary>
    /// <seealso cref="Manager.Event.PeerEntryEvent" />
    /// <seealso cref="Manager.Event.PeerlistCompleteEvent" />
    public class SIPShowPeerAction : ManagerActionEvent
    {
        /// <summary> Creates a new empty <see cref="SIPShowPeerAction"/>.</summary>
        public SIPShowPeerAction()
        {
        }

        /// <summary>
        ///     Creates a new <see cref="SIPShowPeerAction"/> that requests the details about the given SIP peer.
        /// </summary>
        public SIPShowPeerAction(string peer)
        {
            this.Peer = peer;
        }

        /// <summary>
        ///     Get the name of the action, i.e. "SIPShowPeer".
        /// </summary>
        public override string Action
        {
            get { return "SIPShowPeer"; }
        }

        /// <summary>
        ///     Get/Set the name of the peer to retrieve.<br />
        ///     This parameter is mandatory.
        /// </summary>
        public string Peer { get; set; }

        public override Type ActionCompleteEventClass()
        {
            return typeof (PeerlistCompleteEvent);
        }
    }
}