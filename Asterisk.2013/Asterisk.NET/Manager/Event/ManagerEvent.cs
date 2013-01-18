using System;
using System.Text;
using System.Collections.Generic;

namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// Abstract base class for all Events that can be received from the Asterisk server.<br/>
	/// Events contain data pertaining to an event generated from within the Asterisk
	/// core or an extension module.<br/>
	/// There is one conrete subclass of ManagerEvent per each supported Asterisk
	/// Event.
	/// </summary>
	public abstract class ManagerEvent : EventArgs, IParseSupport
	{
		private DateTime dateReceived;
		private string privilege;
		private string server;
		private double timestamp;

		private string uniqueId;
		private string channel;
		private ManagerConnection src;
		protected Dictionary<string, string> attributes;

		#region Constructors 
		public ManagerEvent()
		{
			this.dateReceived = DateTime.Now;
		}

		public ManagerEvent(ManagerConnection source)
			: this()
		{
			this.src = source as ManagerConnection;
		}
		#endregion


		#region Attributes 
		/// <summary>
		/// Store all unknown (without setter) keys from manager event.<br/>
		/// Use in default Parse method <see cref="Parse(string key, string value)"/>.
		/// </summary>
		public Dictionary<string, string> Attributes
		{
			get { return attributes; }
		}
		#endregion

		#region Server 
		/// <summary>
		/// Specify a server to which to send your commands (x.x.x.x or hostname).<br/>
		/// This should match the server name specified in your config file's "host" entry.
		/// If you do not specify a server, the proxy will pick the first one it finds -- fine in single-server configurations.
		/// </summary>
		public string Server
		{
			get { return server; }
			set { server = value; }
		}
		#endregion

		#region Timestamp 
		/// <summary>
		/// Returns the timestamp for this event.<br/>
		/// The timestamp property is available in Asterisk since 1.4
		/// if enabled in manager.conf by setting timestampevents = yes.
		/// In contains the time the event was generated in seconds since the epoch.
		/// </summary>
		public double Timestamp
		{
			get { return this.timestamp; }
			set { this.timestamp = value; }
		}
		#endregion

		#region DateReceived
		/// <summary>
		/// Get/Set the point in time this event was received from the Asterisk server.<br/>
		/// Pseudo events that are not directly received from the asterisk server
		/// (for example ConnectEvent and DisconnectEvent) may return <code>null</code>.
		/// </summary>
		public DateTime DateReceived
		{
			get { return this.dateReceived; }
			set { this.dateReceived = value; }
		}
		#endregion

		#region Privilege 
		/// <summary>
		/// Get/Set the AMI authorization class of this event.<br/>
		/// This is one or more of system, call, log, verbose, command, agent or user.
		/// Multiple privileges are separated by comma.<br/>
		/// Note: This property is not available from Asterisk 1.0 servers.
		/// </summary>
		public string Privilege
		{
			get { return privilege; }
			set { this.privilege = value; }
		}
		#endregion

		#region Source 
		/// <summary>
		/// Event source.
		/// </summary>
		public ManagerConnection Source 
		{
			get { return this.src; }
		}
		#endregion

		#region UniqueId 
		/// <summary>
		/// Get/Set the unique id of the channel.
		/// </summary>
		public string UniqueId
		{
			get { return uniqueId; }
			set { this.uniqueId = value; }
		}
		#endregion

		#region Channel 
		/// <summary>
		/// Get/Set the name of the channel.
		/// </summary>
		public string Channel
		{
			get { return channel; }
			set { this.channel = value; }
		}
		#endregion


		#region Parse(string key, string value) 
		/// <summary>
		/// Unknown properties parser
		/// </summary>
		/// <param name="key">key name</param>
		/// <param name="value">key value</param>
		/// <returns>true - value parsed, false - can't parse value</returns>
		public virtual bool Parse(string key, string value)
		{
			if (attributes == null)
				attributes = new Dictionary<string, string>();

			if (attributes.ContainsKey(key))
				// Key already presents, add with delimiter
				attributes[key] += string.Concat(Common.LINE_SEPARATOR, value);
			else
				attributes.Add(key, value);
			return true;
		}
		#endregion

		#region ParseSpecial(Dictionary<string, string> attributes)
		/// <summary>
		/// Unknown properties parser
		/// </summary>
		/// <param name="attributes">dictionary</param>
		/// <returns>updated dictionary</returns>
		public virtual Dictionary<string, string> ParseSpecial(Dictionary<string, string> attributes)
		{
			return attributes;
		}
		#endregion

		#region ToString()
		public override string ToString()
		{
			return Helper.ToString(this);
		}
		#endregion
	}
}
