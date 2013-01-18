using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Asterisk.NET.Manager.Event
{
	public abstract class AbstractAgentVariables : ManagerEvent
	{
		private Dictionary<string, string> variables;

		public AbstractAgentVariables(ManagerConnection source)
			: base(source)
		{ }

		#region Variable
		/// <summary>
		/// Get/Set the variables to set on the queue call in native asterisk format.<br/>
		/// Example: "VAR1=abc|VAR2=def".
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
		public IDictionary GetVariables()
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

		#region SetVariable(string name, string val)
		/// <summary>
		/// Sets a variable dictionary on the originated call. Replaces any existing variable with the same name.
		/// </summary>
		public void SetVariable(string key, string val)
		{
			if (variables == null)
				variables = new Dictionary<string, string>();
			if (variables.ContainsKey(key))
				variables[key] = val;
			else
				variables.Add(key, val);
		}
		#endregion

		#region GetVariable(string name)
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
	}
}
