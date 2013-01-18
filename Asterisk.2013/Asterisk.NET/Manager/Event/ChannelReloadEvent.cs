using System;
using System.Collections.Generic;
using System.Text;

namespace Asterisk.NET.Manager.Event
{
	public class ChannelReloadEvent : ManagerEvent
	{
		private string channelType;
		private string reloadreason;
		private int registryCount;
		private int userCount;
		private int peerCount;

		/// <summary>
		/// For SIP peers this is "SIP".
		/// </summary>
		public string ChannelType
		{
			get { return channelType; }
			set { this.channelType = value; }
		}

		/// <summary>
		/// Get/Set the name of the channel.
		/// </summary>
		public string ReloadReason
		{
			get { return reloadreason; }
			set { this.reloadreason = value; }
		}

		public int UserCount
		{
			get { return userCount; }
			set { this.userCount = value; }
		}

		public int PeerCount
		{
			get { return peerCount; }
			set { this.peerCount = value; }
		}

		public int RegistryCount
		{
			get { return registryCount; }
			set { this.registryCount = value; }
		}
		
		public ChannelReloadEvent(ManagerConnection source)
			: base(source)
		{
		}

	}
}
