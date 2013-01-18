using System.Text;
using System.Collections.Generic;

namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// This class implements the ManagerAction interface
	/// and can serve as base class for your concrete Action implementations.
	/// </summary>
	public abstract class ManagerAction
	{
		private string actionId;
		private string server;
		private string proxyKey;

		/// <summary>
		/// Manager API Action key. Also use as ProxyAction key to <see cref="ProxyAction">ProxyAction</see> actions.
		/// </summary>
		public abstract string Action
		{
			get;
		}

		#region ActionId 
		public string ActionId
		{
			get { return this.actionId; }
			set { this.actionId = value; }
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
			get { return this.server; }
			set { this.server = value; }
		}
		#endregion

		#region ProxyKey 
		/// <summary>
		/// You can use this as a simple authentication mechanism.<br/>
		/// Rather than have to login with a username & password,
		/// you can specify a <b>ProxyKey</b> that must be passed from
		/// a client before requests are processed.<br/>
		/// This is helpful in situations where you would like to authenticate and
		/// execute an action in a single step.
		/// </summary>
		public virtual string ProxyKey
		{
			get { return this.proxyKey; }
			set { this.proxyKey = value; }
		}
		#endregion

		public override string ToString()
		{
			return Helper.ToString(this);
		}
	}
}
