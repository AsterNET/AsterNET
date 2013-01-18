namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A HoldedCallEvent is triggered when a channel is put on hold.<br/>
	/// It is implemented in <code>res/res_features.c</code>
	/// </summary>
	public class HoldedCallEvent : ManagerEvent
	{
		private string uniqueId1;
		private string uniqueId2;
		private string channel1;
		private string channel2;

		/// <summary>
		/// Get/Set the unique id of the channel that put the other channel on hold.
		/// </summary>
		public string UniqueId1
		{
			get { return uniqueId1; }
			set { this.uniqueId1 = value; }
		}
		/// <summary>
		/// Get/Set the unique id of the channel that has been put on hold.
		/// </summary>
		public string UniqueId2
		{
			get { return uniqueId2; }
			set { this.uniqueId2 = value; }
		}
		/// <summary>
		/// Get/Set the name of the channel that put the other channel on hold.
		/// </summary>
		public string Channel1
		{
			get { return channel1; }
			set { this.channel1 = value; }
		}
		/// <summary>
		/// Get/Set the name of the channel that has been put on hold.
		/// </summary>
		public string Channel2
		{
			get { return channel2; }
			set { this.channel2 = value; }
		}
		
		public HoldedCallEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}