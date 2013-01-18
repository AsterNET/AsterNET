using System;
namespace Asterisk.NET.FastAGI.Command
{
	/// <summary>
	/// Retrieves an entry in the Asterisk database for a given family and key.<br/>
	/// Returns 0 if is not set. Returns 1 if the variable is set and returns the
	/// value in parenthesis.<br/>
	/// Example return code: 200 result=1 (testvariable)
	/// </summary>
	public class DatabaseGetCommand : AGICommand
	{
		/// <summary> The family of the key to retrieve.</summary>
		private string family;
		/// <summary> The key to retrieve.</summary>
		private string varKey;

		/// <summary>
		/// Get/Set 
		/// </summary>
		public string Family
		{
			get { return family; }
			set { this.family = value; }
		}
		/// <summary>
		/// Get/Set the the key to retrieve.
		/// </summary>
		public string Key
		{
			get { return varKey; }
			set { this.varKey = value; }
		}
		
		/// <summary>
		/// Creates a new DatabaseGetCommand.
		/// </summary>
		/// <param name="family">the family of the key to retrieve.</param>
		/// <param name="key">the key to retrieve.</param>
		public DatabaseGetCommand(string family, string key)
		{
			this.family = family;
			this.varKey = key;
		}
		
		public override string BuildCommand()
		{
			return "DATABASE GET " + EscapeAndQuote(family) + " " + EscapeAndQuote(varKey);
		}
	}
}