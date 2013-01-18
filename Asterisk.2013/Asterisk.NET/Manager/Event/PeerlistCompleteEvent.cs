namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A PeerlistCompleteEvent is triggered after the details of all peers has been reported in response to an SIPPeersAction or SIPShowPeerAction.<br/>
	/// Available since Asterisk 1.2
	/// </summary>
	/// <seealso cref="Manager.event.PeerEntryEvent"/>
	/// <seealso cref="Manager.Action.SIPPeersAction"/>
	/// <seealso cref="Manager.Action.SIPShowPeerAction"/>
	public class PeerlistCompleteEvent : ResponseEvent
	{
		private int listItems;

		/// <summary>
		/// Get/Set the number of PeerEvents that have been reported.</summary>
		public int ListItems
		{
			get { return listItems; }
			set { this.listItems = value; }
		}

		public PeerlistCompleteEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}