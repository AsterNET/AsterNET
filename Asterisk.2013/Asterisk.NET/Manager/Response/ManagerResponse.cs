using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Asterisk.NET.Manager.Response
{
	/// <summary>
	/// Represents a response received from the Asterisk server as the result of a
	/// previously sent ManagerAction.<br/>
	/// The response can be linked with the action that caused it by looking the
	/// action id attribute that will match the action id of the corresponding
	/// action.
	/// </summary>
	public class ManagerResponse : IParseSupport
	{
		private DateTime dateReceived;
		private string privilege;
		private string actionId;
		private string response;
		private string message;
		private string uniqueId;
		private string server;
		protected Dictionary<string, string> attributes;

		#region Constructor - ManagerEvent() 
		public ManagerResponse()
		{
			this.dateReceived = DateTime.Now;
		}
		public ManagerResponse(Dictionary<string, string> attributes)
			: this()
		{
			Helper.SetAttributes(this, attributes);
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
			get { return this.server; }
			set { this.server = value; }
		}
		#endregion

		#region DateReceived 
		/// <summary>
		/// Get/Set the point in time this response was received from the asterisk server.
		/// </summary>
		public DateTime DateReceived
		{
			get { return dateReceived; }
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

		#region ActionId 
		/// <summary>
		/// Get/Set the action id received with this response referencing the action that generated this response.
		/// </summary>
		public string ActionId
		{
			get { return actionId; }
			set { this.actionId = value; }
		}
		#endregion

		#region Message 
		/// <summary>
		/// Get/Set the message received with this response.<br/>
		/// The content depends on the action that generated this response.
		/// </summary>
		public string Message
		{
			get { return message; }
			set { this.message = value; }
		}
		#endregion

		#region Response 
		/// <summary>
		/// Get/Set the value of the "Response:" line.<br/>
		/// This typically a String like "Success" or "Error" but depends on the action that generated this response.
		/// </summary>
		public string Response
		{
			get { return response; }
			set { this.response = value; }
		}
		#endregion

		#region UniqueId 
		/// <summary>
		/// Get/Set the unique id received with this response.<br/>
		/// The unique id is used to keep track of channels created by the action sent, for example an OriginateAction.
		/// </summary>
		public string UniqueId
		{
			get { return uniqueId; }
			set { this.uniqueId = value; }
		}
		#endregion


		#region IsSuccess() 
		/// <summary>
		/// Return true if Response is success
		/// </summary>
		/// <returns></returns>
		public bool IsSuccess()
		{
			return response == "Success";
		}
		#endregion

		#region GetAttribute(string key) 
		/// <summary>
		/// Returns the value of the attribute with the given key.<br/>
		/// This is particulary important when a response contains special 
		/// attributes that are dependent on the action that has been sent.<br/>
		/// An example of this is the response to the GetVarAction.
		/// It contains the value of the channel variable as an attribute
		/// stored under the key of the variable name.<br/>
		/// Example:
		/// <pre>
		/// GetVarAction action = new GetVarAction();
		/// action.setChannel("SIP/1310-22c3");
		/// action.setVariable("ALERT_INFO");
		/// ManagerResponse response = connection.SendAction(action);
		/// String alertInfo = response.getAttribute("ALERT_INFO");
		/// </pre>
		/// As all attributes are internally stored in lower case the key is
		/// automatically converted to lower case before lookup.
		/// </summary>
		/// <param name="key">the key to lookup.</param>
		/// <returns> the value of the attribute stored under this key or
		/// <code>null</code> if there is no such attribute.
		/// </returns>
		public string GetAttribute(string key)
		{
			return (string) attributes[key.ToLower(Helper.CultureInfo)];
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
