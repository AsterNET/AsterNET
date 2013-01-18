using Asterisk.NET.Manager.Event;
namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A FaxReceivedEvent is triggered by spandsp after a new fax has been received.<br/>
	/// It is only available if you installed the spandsp patches to Asterisk.<br/>
	/// See http://soft-switch.org/installing-spandsp.html for details.<br/>
	/// Implemented in <code>apps/app_rxfax.c</code>.
	/// </summary>
	public class FaxReceivedEvent : AbstractAgentEvent
	{
		private string exten;
		private string callerId;
		private string remoteStationId;
		private string localStationId;
		private int pagesTransferred;
		private int resolution;
		private int transferRate;
		private string filename;

		public FaxReceivedEvent(ManagerConnection source)
			: base(source)
		{
		}

		/// <summary>
		/// Get/Set the extension in Asterisk's dialplan the fax was received
		/// </summary>
		public string Exten
		{
			get { return exten; }
			set { exten = value; }
		}

		/// <summary>
		/// Get/Set the Caller*ID of the calling party or an empty string if none is
		/// </summary>
		public string CallerId
		{
			get { return callerId; }
			set { callerId = value; }
		}

		/// <summary>
		/// Get/Set the identifier of the remote fax station.
		/// </summary>
		public string RemoteStationId
		{
			get { return remoteStationId; }
			set { remoteStationId = value; }
		}

		/// <summary>
		/// Get/Set the identifier of the local fax station.
		/// </summary>
		public string LocalStationId
		{
			get { return localStationId; }
			set { localStationId = value; }
		}

		/// <summary>
		/// Get/Set the number of pages transferred.
		/// </summary>
		public int PagesTransferred
		{
			get { return pagesTransferred; }
			set { pagesTransferred = value; }
		}

		/// <summary>
		/// Get/Set the row resolution of the received fax.
		/// </summary>
		public int Resolution
		{
			get { return resolution; }
			set { resolution = value; }
		}

		/// <summary>
		/// Get/Set the transfer rate in bits/s.
		/// </summary>
		public int TransferRate
		{
			get { return transferRate; }
			set { transferRate = value; }
		}

		/// <summary>
		/// Get/Set the filename of the received fax including its full path on the Asterisk server.
		/// </summary>
		public string Filename
		{
			get { return filename; }
			set { filename = value; }
		}
	}
}
