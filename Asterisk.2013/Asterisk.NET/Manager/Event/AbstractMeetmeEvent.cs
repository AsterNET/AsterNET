namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// Abstract base class providing common properties for meet me (asterisk's conference system) events.
	/// </summary>
	public abstract class AbstractMeetmeEvent : ManagerEvent
	{
		private string meetMe;
		private int userNum;

		/// <summary>
		/// Get/Set the conference number.
		/// </summary>
		public string Meetme
		{
			get { return meetMe; }
			set { this.meetMe = value; }
		}
		public int Usernum
		{
			get { return userNum; }
			set { this.userNum = value; }
		}
		
		public AbstractMeetmeEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}