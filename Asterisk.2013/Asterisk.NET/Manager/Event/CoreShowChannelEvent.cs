using System;

namespace AsterNET.Manager.Event
{
	/// <summary>
	/// Raised when a Queue member's status has changed
	/// </summary>
	public class CoreShowChannelEvent : AbstractChannelEvent
	{
		/// <summary>
		/// Get/Set Channel
		/// </summary>
		public string Channel { get; set; }

		/// <summary>
		/// Get/Set Channel
		/// </summary>
		public string Language { get; set; }

		/// <summary>
		/// Get/Set Context
		/// </summary>
		public string Context { get; set; }

		/// <summary>
		/// Get/Set Exten
		/// </summary>
		public string Exten { get; set; }

		/// <summary>
		/// Get/Set Priority
		/// </summary>
		public int Priority { get; set; }

		/// <summary>
		/// Get/Set Uniqueid
		/// </summary>
		public string Uniqueid { get; set; }

		/// <summary>
		/// Get/Set Linkedid: Uniqueid of the oldest channel associated with this channel.
		/// </summary>
		public string Linkedid { get; set; }

		/// <summary>
		/// Get/Set Application: Application currently executing on the channel
		/// </summary>
		public string Application { get; set; }

		/// <summary>
		/// Get/Set ApplicationData: Data given to the currently executing application
		/// </summary>
		public string ApplicationData { get; set; }

		/// <summary>
		/// Get/Set Duration: The amount of time the channel has existed
		/// </summary>
		public TimeSpan Duration { get; set; }

		/// <summary>
		/// Get/Set BridgeId: Identifier of the bridge the channel is in, may be empty if not in one
		/// </summary>
		public Guid BridgeId { get; set; }

		/// <summary>
		/// Creates a new CoreShowChannelEvent
		/// </summary>
		/// <param name="source">ManagerConnection passed through in the event.</param>
		public CoreShowChannelEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}
