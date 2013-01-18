using System;

namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// The GetVarAction queries for a channel variable.
	/// </summary>
	public class GetVarAction : ManagerAction
	{
		private string channel;
		private string varName;

		/// <summary>
		/// Creates a new empty GetVarAction.
		/// </summary>
		public GetVarAction()
		{
		}

		/// <summary>
		/// Creates a new GetVarAction that queries for the given global variable.
		/// </summary>
		/// <param name="variable">the name of the global variable to query.</param>
		public GetVarAction(string variable)
		{
			this.varName = variable;
		}

		/// <summary>
		/// Creates a new GetVarAction that queries for the given local channel variable.
		/// </summary>
		/// <param name="channel">the name of the channel, for example "SIP/1234-9cd".</param>
		/// <param name="variable">the name of the variable to query.</param>
		public GetVarAction(string channel, string variable)
		{
			this.channel = channel;
			this.varName = variable;
		}

		/// <summary>
		/// Get the name of this action, i.e. "GetVar".
		/// </summary>
		override public string Action
		{
			get { return "GetVar"; }
		}
		/// <summary>
		/// Get/Set the name of the channel, if you query for a local channel variable.
		/// Leave empty to query for a global variable.
		/// </summary>
		public string Channel
		{
			get { return this.channel; }
			set { this.channel = value; }
		}
		/// <summary>
		/// Get/Set the name of the variable to query.
		/// </summary>
		public string Variable
		{
			get { return this.varName; }
			set { this.varName = value; }
		}
	}
}