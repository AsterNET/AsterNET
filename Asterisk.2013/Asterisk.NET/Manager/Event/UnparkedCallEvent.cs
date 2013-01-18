namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A UnparkedCallEvent is triggered when a channel that has been parked is resumed.<br/>
	/// It is implemented in <code>res/res_features.c</code><br/>
	/// Available since Asterisk 1.2
	/// </summary>
	public class UnparkedCallEvent : AbstractParkedCallEvent
	{
		private string from;

		/// <summary>
		/// Get/Set the name of the channel that parked the call.
		/// </summary>
		public string From
		{
			get { return this.from; }
			set { this.from = value; }
		}

		public UnparkedCallEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}