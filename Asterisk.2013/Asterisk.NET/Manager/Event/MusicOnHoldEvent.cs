namespace AsterNET.Manager.Event
{
	/// <summary>
	/// The MusicOnHoldEvent event triggers when the music starts or ends playing the hold music.
	/// </summary>
	public class MusicOnHoldEvent : ManagerEvent 
	{
		/// <summary>
		/// Creates a new instance of the class <see cref="MusicOnHoldEvent"/>.
		/// </summary>
		public MusicOnHoldEvent(ManagerConnection source) : base(source)
		{
		}

		/// <summary>
		/// States
		/// </summary>
		public enum MusicOnHoldStates
		{
			/// <summary>
			/// Unknown
			/// </summary>
			Unknown,

			/// <summary>
			/// Music on hold is started.
			/// </summary>
			Start,

			/// <summary>
			/// Music on hold is stoped.
			/// </summary>
			Stop
		}

		/// <summary>
		/// Get or set state
		/// </summary>
		public MusicOnHoldStates State { get; set; }
	}
}
