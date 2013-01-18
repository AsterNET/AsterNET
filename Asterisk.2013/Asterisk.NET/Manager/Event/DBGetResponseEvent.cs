namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A DBGetResponseEvent is sent in response to a DBGetAction and contains the entry that was queried.<br/>
	/// Available since Asterisk 1.2
	/// </summary>
	/// <seealso cref="Manager.Action.DBGetAction" />
	public class DBGetResponseEvent : ResponseEvent
	{
		private string family;
		private string key;
		private string val;

		/// <summary>
		/// Get/Set the family of the database entry that was queried.
		/// </summary>
		public string Family
		{
			get { return this.family; }
			set { this.family = value; }
		}
		/// <summary>
		/// Get/Set the key of the database entry that was queried.
		/// </summary>
		public string Key
		{
			get { return this.key; }
			set { this.key = value; }
		}
		/// <summary>
		/// Get/Set the value of the database entry that was queried.
		/// </summary>
		public string Val
		{
			get { return val; }
			set { this.val = value; }
		}

		public DBGetResponseEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}