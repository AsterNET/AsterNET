using System;
namespace Asterisk.NET.FastAGI.Command
{
	/// <summary>
	/// Deletes an entry in the Asterisk database for a given family and key.<br/>
	/// Returns 1 if successful, 0 otherwise.
	/// </summary>
	public class DatabaseDelTreeCommand : AGICommand
	{
		/// <summary> The family of the key to delete.</summary>
		private string family;
		/// <summary> The key to delete.</summary>
		private string keyTree;

		/// <summary>
		/// Get/Set the family of the key to delete.
		/// </summary>
		public string Family
		{
			get { return family; }
			set { this.family = value; }
		}
		/// <summary>
		/// Get/Set the the key to delete.
		/// </summary>
		public string KeyTree
		{
			get { return keyTree; }
			set { this.keyTree = value; }
		}
		/// <summary>
		/// Creates a new DatabaseDelCommand.
		/// </summary>
		/// <param name="family">the family of the key to delete.</param>
		/// <param name="key">the key to delete.</param>
		public DatabaseDelTreeCommand(string family)
		{
			this.family = family;
		}
		/// <summary>
		/// Creates a new DatabaseDelCommand.
		/// </summary>
		/// <param name="family">the family of the key to delete.</param>
		/// <param name="keytree">the key to delete.</param>
		public DatabaseDelTreeCommand(string family, string keytree)
		{
			this.family = family;
			this.keyTree = keytree;
		}

		public override string BuildCommand()
		{
			if (family != null)
			{
				if (keyTree != null)
				{
					return "DATABASE DELTREE " + EscapeAndQuote(family) + " " + EscapeAndQuote(keyTree);
				}
				return "DATABASE DELTREE " + EscapeAndQuote(family);
			}
			throw new ArgumentNullException("Family");
		}
	}
}