using System;
namespace Asterisk.NET.Manager.Action
{
	
	/// <summary>
	/// Retrieves an entry in the Asterisk database for a given family and key.<br/>
	/// If an entry is found a DBGetResponseEvent is sent by Asterisk containing the
	/// value, otherwise a ManagerError indicates that no entry matches.
	/// </summary>
	/// <seealso cref="Asterisk.NET.Manager.Event.DBGetResponseEvent" />
	public class DBGetAction : ManagerActionEvent
	{
		private string family;
		private string key;

		public override string Action
		{
			get { return "DBGet"; }
		}
		/// <summary> Returns the family of the key.
		/// 
		/// </summary>
		/// <returns> the family of the key.
		/// </returns>
		/// <summary> Sets the family of the key.
		/// 
		/// </summary>
		/// <param name="family">the family of the key.
		/// </param>
		public string Family
		{
			get { return family; }
			set { this.family = value; }
		}
		/// <summary>
		/// Get/Set the the key of the entry to retrieve.
		/// </summary>
		public string Key
		{
			get { return key; }
			set { this.key = value; }
		}
		public override Type ActionCompleteEventClass()
		{
			return typeof(Event.DBGetResponseEvent);
		}
		
		/// <summary>
		/// Creates a new empty DBGetAction.
		/// </summary>
		public DBGetAction()
		{
		}
		
		/// <summary>
		/// Creates a new DBGetAction that retrieves the value of the database entry
		/// with the given key in the given family.
		/// </summary>
		/// <param name="family">the family of the key</param>
		/// <param name="key">the key of the entry to retrieve</param>
		public DBGetAction(string family, string key)
		{
			this.family = family;
			this.key = key;
		}
	}
}