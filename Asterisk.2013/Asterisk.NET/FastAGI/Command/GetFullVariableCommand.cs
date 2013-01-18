using System;
using System.Text;

namespace Asterisk.NET.FastAGI.Command
{
	/// <summary>
	/// Returns the value of the given channel varible and understands complex
	/// variable names and builtin variables, unlike the GetVariableCommand.<br/>
	/// You can also use this command to use custom Asterisk functions. Syntax is "func(args)".<br/>
	/// Returns 0 if the variable is not set or channel does not exist. Returns 1 if
	/// the variable is set and returns the variable in parenthesis.<br/>
	/// Example return code: 200 result=1 (testvariable)
	/// Available since Asterisk 1.2
	/// </summary>
	public class GetFullVariableCommand : AGICommand
	{
		private string varName;
		private string channel;

		/// <summary>
		/// Creates a new GetFullVariableCommand.
		/// </summary>
		/// <param name="variable">the name of the variable to retrieve.</param>
		public GetFullVariableCommand(string variable)
		{
			this.varName = variable;
		}

		/// <summary>
		/// Creates a new GetFullVariableCommand.
		/// </summary>
		/// <param name="variable">the name of the variable to retrieve.</param>
		/// <param name="channel">the name of the channel.</param>
		public GetFullVariableCommand(string variable, string channel)
		{
			this.varName = variable;
			this.channel = channel;
		}

		/// <summary>
		/// Get/Set the name of the variable to retrieve.
		/// </summary>
		public string Variable
		{
			get { return varName; }
			set { this.varName = value;}
		}

		/// <summary>
		/// Get/Set the name of the channel.
		/// </summary>
		public string Channel
		{
			get { return channel; }
			set { this.channel = value; }
		}

		public override string BuildCommand()
		{
			StringBuilder sb;

			sb = new StringBuilder("GET FULL VARIABLE ");
			sb.Append(EscapeAndQuote(varName));

			if (channel != null)
			{
				sb.Append(" ");
				sb.Append(EscapeAndQuote(channel));
			}
			return sb.ToString();
		}
	}
}