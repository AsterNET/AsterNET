using System.Collections;
using System.Collections.Generic;

namespace Asterisk.NET.Manager.Response
{
	/// <summary>
	/// Corresponds to a CommandAction.<br/>
	/// Asterisk's handling of the command action is generelly quite hairy.
	/// It sends a "Response: Follows" line followed by the raw output of the command including empty lines.
	/// At the end of the command output a line containing "--END COMMAND--" is sent.
	/// The reader parses this response into a CommandResponse object to hide these details.
	/// </summary>
	/// <seealso cref="Manager.Action.CommandAction"/>
	public class CommandResponse : ManagerResponse
	{
		protected internal List<string> result;

		/// <summary>
		/// Get/Set a List containing strings representing the lines returned by the CLI command.
		/// </summary>
		public List<string> Result
		{
			get { return result; }
			set { this.result = value; }
		}
	}
}