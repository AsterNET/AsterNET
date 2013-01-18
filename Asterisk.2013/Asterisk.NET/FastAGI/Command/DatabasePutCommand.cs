using System;
namespace Asterisk.NET.FastAGI.Command
{
	/// <summary>
	/// Adds or updates an entry in the Asterisk database for a given family, key, and value.<br/>
	/// Returns 1 if successful, 0 otherwise.
	/// </summary>
	public class DatabasePutCommand : AGICommand
	{
		/// <summary> The family of the key to set.</summary>
		private string family;
		/// <summary> The key to set.</summary>
		private string varKey;
		/// <summary> The value to set.</summary>
		private string varValue;

		/// <summary>
		/// Get/Set the family of the key to set.
		/// </summary>
		public string Family
		{
			get { return family; }
			set { this.family = value; }
		}
		/// <summary>
		/// Get/Set the the key to set.
		/// </summary>
		public string Key
		{
			get { return varKey; }
			set { this.varKey = value; }
		}
		/// <summary>
		/// Get/Set the value to set.
		/// </summary>
		public string Value
		{
			get { return varValue; }
			set { this.varValue = value; }
		}
		
		/// <summary>
		/// Creates a new DatabasePutCommand.
		/// </summary>
		/// <param name="family">the family of the key to set.</param>
		/// <param name="key">the key to set.</param>
		/// <param name="value">the value to set.</param>
		public DatabasePutCommand(string family, string key, string value)
		{
			this.family = family;
			this.varKey = key;
			this.varValue = value;
		}
		
		public override string BuildCommand()
		{
			return "DATABASE PUT " + EscapeAndQuote(family) + " " + EscapeAndQuote(varKey) + " " + EscapeAndQuote(varValue);
		}
	}
}