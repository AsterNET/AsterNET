namespace Asterisk.NET.FastAGI.Command
{
	/// <summary>
	/// Returns the value of the given channel varible.<br/>
	/// Since Asterisk 1.2 you can also use this command to use custom Asterisk  functions. Syntax is "func(args)".<br/>
	/// Returns 0 if the variable is not set. Returns 1 if the variable is set and returns the variable in parenthesis.<br/>
	/// Example return code: 200 result=1 (testvariable)
	/// </summary>
	public class GetVariableCommand : AGICommand
	{
		/// <summary> The name of the variable to retrieve.</summary>
		private string varName;

		/// <summary>
		/// Get/Set the name of the variable to retrieve.<br>
		/// Since Asterisk 1.2 you can also use custom dialplan functions (like "func(args)") as variable.
		/// </summary>
		public string Variable
		{
			get { return varName; }
			set { this.varName = value; }
		}

		/// <summary>
		/// Creates a new GetVariableCommand.
		/// </summary>
		/// <param name="variable">the name of the variable to retrieve.</param>
		public GetVariableCommand(string variable)
		{
			this.varName = variable;
		}
		
		public override string BuildCommand()
		{
			return "GET VARIABLE " + EscapeAndQuote(varName);
		}
	}
}