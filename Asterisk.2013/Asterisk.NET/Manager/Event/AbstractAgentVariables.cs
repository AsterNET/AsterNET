using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Abstract base class for several agent related variables.
    /// </summary>
    public abstract class AbstractAgentVariables : ManagerEvent, IActionVariable
	{
		private Dictionary<string, string> variables;

        /// <summary>
        ///     Creates a new <see cref="AbstractAgentVariables"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public AbstractAgentVariables(ManagerConnection source)
			: base(source)
		{ }

		#region Variable
		/// <summary>
		///     Get/Set the variables to set on the queue call in native asterisk format.<br/>
		///     Example: "VAR1=abc|VAR2=def".
		/// </summary>
		[Obsolete("Use GetVariables and SetVariables instead.", true)]
		public string Variable
		{
			get { return null; /* return Helper.JoinVariables(variables, Common.GET_VAR_DELIMITER(this.Server), "="); */ }
			set { /* variables = Helper.ParseVariables(variables, value, Common.GET_VAR_DELIMITER(this.Server)); */ }
		}
		#endregion

		#region GetVariables()
		/// <summary>
		///     Get the variables dictionary to set on the originated call.
		/// </summary>
		public Dictionary<string, string> GetVariables()
		{
			return variables;
		}
		#endregion

		#region SetVariables(Dictionary<string, string> vars)
		/// <summary>
		///     Set the variables dictionary to set on the originated call.
		/// </summary>
		public void SetVariables(Dictionary<string, string> vars)
		{
			this.variables = vars;
		}
		#endregion

		#region SetVariable(string name, string val)
		/// <summary>
		///     Sets a variable dictionary on the originated call. Replaces any existing variable with the same name.
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
		///     Gets a variable on the originated call. Replaces any existing variable with the same name.
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
