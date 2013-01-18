using System;
namespace Asterisk.NET.FastAGI
{
	/// <summary>
	/// An InvalidCommandSyntaxException is thrown when the reader receives a reply with status code 520.
	/// </summary>
	public class InvalidCommandSyntaxException : AGIException
	{
		/// <summary>
		/// Returns the synopsis of the command that was called with invalid syntax.
		/// </summary>
		/// <returns>the synopsis of the command that was called with invalid syntax.</returns>
		public string Synopsis
		{
			get { return synopsis; }
		}
		/// <summary>
		/// Returns a description of the command that was called with invalid syntax.
		/// </summary>
		/// <returns>a description of the command that was called with invalid syntax.</returns>
		public string Usage
		{
			get { return usage; }
		}

		private string synopsis;
		private string usage;
		
		/// <summary>
		/// Creates a new InvalidCommandSyntaxException with the given synopsis and usage.
		/// </summary>
		/// <param name="synopsis">the synopsis of the command.</param>
		/// <param name="usage">the usage of the command.</param>
		public InvalidCommandSyntaxException(string synopsis, string usage)
			: base("Invalid command syntax: " + synopsis)
		{
			this.synopsis = synopsis;
			this.usage = usage;
		}
	}
}