namespace AsterNET.Manager.Event
{
	/// <summary>
	/// A HangupRequestEvent is raised when a channel is hang up.<br/>
	/// </summary>
	public class HangupRequestEvent : AbstractChannelEvent
	{
		/// <inheritdoc />
		public HangupRequestEvent(ManagerConnection source) : base(source)
		{
		}

		/// <summary>
		///  Uniqueid of the oldest channel associated with this channel.
		/// </summary>
		public string LinkedId { get; set; }

		/// <summary>
		/// Get/Set the cause of the hangup.
		/// </summary>
		public int Cause { get; set; }
	}
}