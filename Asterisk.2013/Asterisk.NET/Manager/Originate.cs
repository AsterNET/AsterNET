using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Asterisk.NET.Manager
{
	public class Originate
	{
		private string channel;
		private string exten;
		private string context;
		private int priority;
		private long timeout;
		private string callerId;
		private Dictionary<string, string> variables;
		private string account;
		private string application;
		private string data;

		#region Account
		/// <summary>
		/// Get/Set the account code to use for the originated call.
		/// The account code is included in the call detail record generated for this
		/// call and will be used for billing.
		/// </summary>
		public string Account
		{
			get { return account; }
			set { this.account = value; }
		}
		#endregion
		#region CallerId
		/// <summary>
		/// Get/Set the caller id to set on the outgoing channel.
		/// </summary>
		public string CallerId
		{
			get { return callerId; }
			set { this.callerId = value; }
		}
		#endregion
		#region Channel
		/// <summary>
		/// Get/Set the name of the channel to connect to the outgoing call.
		/// This property is required.
		/// </summary>
		public string Channel
		{
			get { return channel; }
			set { this.channel = value; }
		}
		#endregion
		#region Context
		/// <summary>
		/// Get/Set the name of the context of the extension to connect to.
		/// If you set the context you also have to set the exten and priority properties.
		/// </summary>
		public string Context
		{
			get { return context; }
			set { this.context = value; }
		}
		#endregion
		#region Exten
		/// <summary>
		/// Get/Set the extension to connect to.
		/// If you set the extension you also have to set the context and priority properties.
		/// </summary>
		public string Exten
		{
			get { return exten; }
			set { this.exten = value; }
		}
		#endregion
		#region Priority 
		/// <summary>
		/// Get/Set the priority of the extension to connect to. If you set the priority
		/// you also have to set the context and exten properties.
		/// </summary>
		public int Priority
		{
			get { return priority; }
			set { this.priority = value; }
		}
		#endregion
		#region Application 
		/// <summary>
		/// Get/Set the name of the application to connect to.
		/// </summary>
		public string Application
		{
			get { return application; }
			set { this.application = value; }
		}
		#endregion
		#region Data 
		/// <summary>
		/// Get/Set the parameters to pass to the application.
		/// </summary>
		public string Data
		{
			get { return data; }
			set { this.data = value; }
		}
		#endregion
		#region Timeout
		/// <summary>
		/// Get/Set the timeout for the origination (in seconds) for the origination.<br/>
		/// The channel must be answered within this time, otherwise the origination
		/// is considered to have failed and an OriginateFailureEvent is generated.<br/>
		/// If not set, a default value of 30 seconds.
		/// </summary>
		public long Timeout
		{
			get { return timeout / 1000; }
			set { this.timeout = value * 1000; }
		}
		#endregion

		#region Variable
		/// <summary>
		/// Get/Set the variables to set on the originated call.<br/>
		/// Variable assignments are of the form "VARNAME=VALUE". You can specify
		/// multiple variable assignments separated by the '|' character.<br/>
		/// Example: "VAR1=abc|VAR2=def" sets the channel variables VAR1 to "abc" and VAR2 to "def".
		/// </summary>
		public string Variable
		{
			get { return Helper.JoinVariables(variables, Common.VAR_DELIMITER, "="); }
			set { variables = Helper.ParseVariables(variables, value, Common.VAR_DELIMITER); }
		}
		#endregion

		#region GetVariables()
		/// <summary>
		/// Get the variables dictionary to set on the originated call.
		/// </summary>
		public Dictionary<string, string> GetVariables()
		{
			return variables;
		}
		#endregion
		#region SetVariables(IDictionary vars)
		/// <summary>
		/// Set the variables dictionary to set on the originated call.
		/// </summary>
		public void SetVariables(Dictionary<string, string> vars)
		{
			this.variables = vars;
		}
		#endregion
		#region GetVariable(string name, string val)
		/// <summary>
		/// Gets a variable on the originated call. Replaces any existing variable with the same name.
		/// </summary>
		public string GetVariable(string key)
		{
			if (variables == null)
				return string.Empty;
			return variables[key];
		}
		#endregion
		#region SetVariable(string name, string val)
		/// <summary>
		/// Sets a variable dictionary on the originated call. Replaces any existing variable with the same name.
		/// </summary>
		public void SetVariable(string key, string value)
		{
			if (variables == null)
				variables = new Dictionary<string, string>();
			if (variables.ContainsKey(key))
				variables[key] = value;
			else
				variables.Add(key, value);
		}
		#endregion
	}
}