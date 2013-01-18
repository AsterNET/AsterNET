using System;
namespace Asterisk.NET.FastAGI.Command
{
	/// <summary>
	/// Deletes a family or specific keytree within a family in the Asterisk database.<br/>
	/// Returns 1 if successful, 0 otherwise.
	/// </summary>
	public class DatabaseDelCommand : AGICommand
	{
		/// <summary> The family (or family of the keytree) to delete.</summary>
		private string family;
		/// <summary> The keyTree to delete.</summary>
		private string keyTree;

		/// <summary>
		/// Get/Set the family (or family of the keytree) to delete.
		/// </summary>
		public string Family
		{
			get { return family; }
			set { this.family = value; }
		}

		/// <summary>
		/// Get/Set the the keytree to delete.
		/// </summary>
		public string KeyTree
		{
			get { return keyTree; }
			set { this.keyTree = value; }
		}
		
		/// <summary>
		/// Creates a new DatabaseDelCommand to delete a family.
		/// </summary>
		/// <param name="family">the family to delete.</param>
		public DatabaseDelCommand(string family)
		{
			this.family = family;
			this.keyTree = null;
		}
		
		/// <summary>
		/// Creates a new DatabaseDelCommand to delete a keytree.
		/// </summary>
		/// <param name="family">the family of the keytree to delete.</param>
		/// <param name="keyTree">the keytree to delete.</param>
		public DatabaseDelCommand(string family, string keyTree)
		{
			this.family = family;
			this.keyTree = keyTree;
		}
		
		public override string BuildCommand()
		{
			return "DATABASE DELTREE " + EscapeAndQuote(family) + (keyTree == null?"":" " + EscapeAndQuote(keyTree));
		}
	}
}