namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     The MusicOnHoldEvent event triggers when the music starts or ends playing the hold music.<br />
    ///     See <see target="_blank"  href="LINK">LINK</see>
    /// </summary>
    public class MusicOnHoldEvent : ManagerEvent 
	{
        /// <summary>
        ///     Creates a new empty <see cref="MusicOnHoldEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        public MusicOnHoldEvent(ManagerConnection source) : base(source)
		{
		}

		/// <summary>
		///     States
		/// </summary>
		public enum MusicOnHoldStates
		{
			/// <summary>
			///     Unknown
			/// </summary>
			Unknown,
			/// <summary>
			///     Music on hold is started.
			/// </summary>
			Start,
			/// <summary>
			///     Music on hold is stopped.
			/// </summary>
			Stop
		}

		/// <summary>
		/// Get or set state
		/// </summary>
		public MusicOnHoldStates State { get; set; }
	}
}
