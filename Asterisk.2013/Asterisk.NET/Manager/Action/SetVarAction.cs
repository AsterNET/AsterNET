using System;

namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// The SetVar action sets the value of a channel variable for a given channel.
	/// </summary>
	public class SetVarAction : ManagerAction
	{
		/// <summary> The channel on which to set the variable.</summary>
		public string channel;
		/// <summary> The name of the variable to set.</summary>
		public string varName;
		/// <summary> The value to store.</summary>
		public string varValue;

		/// <summary>
		/// Get the name of this action, i.e. "SetVar".
		/// </summary>
		override public string Action
		{
			get { return "SetVar"; }
		}
		/// <summary>
		/// Get/Set the name of the channel.
		/// </summary>
		public string Channel
		{
			get { return channel; }
			set { this.channel = value; }
		}
		/// <summary>
		/// Get/Set the name of the variable to set.
		/// </summary>
		public string Variable
		{
			get { return this.varName; }
			set { this.varName = value; }
		}
		/// <summary>
		/// Get/Set the value to store.
		/// </summary>
		public string Value
		{
			get { return this.varValue; }
			set { this.varValue = value; }
		}
		
		/// <summary>
		/// Creates a new empty SetVarAction.
		/// </summary>
		public SetVarAction()
		{
		}

		/// <summary>
		/// Creates a new SetVarAction that sets the given global variable to a new value.
		/// </summary>
		/// <param name="variable">the name of the global variable to set</param>
		/// <param name="value">the new value</param>
		public SetVarAction(string variable, string value)
		{
			this.varName = variable;
			this.varValue = value;
		}

		/// <summary>
		/// Creates a new SetVarAction that sets the given channel variable of the
		/// given channel to a new value.
		/// </summary>
		/// <param name="channel">the name of the channel to set the variable on</param>
		/// <param name="variable">the name of the channel variable</param>
		/// <param name="value">the new value</param>
		public SetVarAction(string channel, string variable, string value)
		{
			this.channel = channel;
			this.varName = variable;
			this.varValue = value;
		}
	}
}