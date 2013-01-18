using System;

namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// Retrieves a list of all defined SIP peers.<br/>
	/// For each peer that is found a PeerEntryEvent is sent by Asterisk containing
	/// the details. When all peers have been reported a PeerlistCompleteEvent is sent.<br/>
	/// Available since Asterisk 1.2
	/// </summary>
	/// <seealso cref="Manager.event.PeerEntryEvent" />
	/// <seealso cref="Manager.event.PeerlistCompleteEvent" />
	public class SIPPeersAction : ManagerActionEvent
	{
		public override string Action
		{
			get { return "SIPPeers"; }
		}
		public override Type ActionCompleteEventClass()
		{
			return typeof(Event.PeerlistCompleteEvent);
		}
		
		/// <summary>
		/// Creates a new SIPPeersAction.
		/// </summary>
		public SIPPeersAction()
		{
		}
	}
}