namespace AsterNET.Manager.Event
{
	/// <summary>
	/// Abstract base class providing common properties for ChanSpyStartEvent and ChanSpyStopEvent.
	/// </summary>
	public abstract class AbstractChanSpyEvent : ManagerEvent
	{
		/// <inheritdoc />
		protected AbstractChanSpyEvent(ManagerConnection source) : base(source)
		{
		}

		/// <summary>
		/// Spyer channel
		/// </summary>
		public string SpyerChannel { get; set; }

		/// <summary>
		/// A numeric code for the channel's current state, related to SpyerChannelStateDesc
		/// </summary>
		public string SpyerChannelState { get; set; }

		/// <summary>
		/// A description for the channel current state of the spyer.<br />
		///     This is one of
		///     <dl>
		///         <dt>Down</dt>
		///         <dt>Rsrvd</dt>
		///         <dt>OffHook</dt>
		///         <dt>Dialing</dt>
		///         <dt>Ring</dt>
		///         <dt>Ringing</dt>
		///         <dt>Up</dt>
		///         <dt>Busy</dt>
		///         <dt>Dialing Offhook</dt>
		///         <dt>Pre-ring</dt>
		///         <dt>Unknown</dt>
		///     </dl>
		/// </summary>
		public string SpyerChannelStateDesc { get; set; }

		/// <summary>
		/// The caller*ID number of the spyer.
		/// </summary>
		public string SpyerCallerIdNum { get; set; }

		/// <summary>
		/// The caller*ID name of the spyer.
		/// </summary>
		public string SpyerCallerIdName { get; set; }

		/// <summary>
		///  Spyer connected line number.
		/// </summary>
		public string SpyerConnectedLineNum { get; set; }

		/// <summary>
		/// Spyer connected line name.
		/// </summary>
		public string SpyerConnectedLineName { get; set; }

		/// <summary>
		/// Spyer account code.
		/// </summary>
		public string SpyerAccountCode { get; set; }

		/// <summary>
		/// Spyer context.
		/// </summary>
		public string SpyerContext { get; set; }

		/// <summary>
		/// Spyer exten.
		/// </summary>
		public string SpyerExten { get; set; }

		/// <summary>
		/// Spyer priority.
		/// </summary>
		public string SpyerPriority { get; set; }

		/// <summary>
		/// Spyer uniqueId
		/// </summary>
		public string SpyerUniqueId { get; set; }

		/// <summary>
		/// Spyer linkedId.
		/// </summary>
		public string SpyerLinkedId { get; set; }


		/// <summary>
		/// Spyee channel
		/// </summary>
		public string SpyeeChannel { get; set; }

		/// <summary>
		/// A numeric code for the channel's current state, related to SpyeeChannelStateDesc
		/// </summary>
		public string SpyeeChannelState { get; set; }

		/// <summary>
		/// A description for the channel current state of the spyee.<br />
		///     This is one of
		///     <dl>
		///         <dt>Down</dt>
		///         <dt>Rsrvd</dt>
		///         <dt>OffHook</dt>
		///         <dt>Dialing</dt>
		///         <dt>Ring</dt>
		///         <dt>Ringing</dt>
		///         <dt>Up</dt>
		///         <dt>Busy</dt>
		///         <dt>Dialing Offhook</dt>
		///         <dt>Pre-ring</dt>
		///         <dt>Unknown</dt>
		///     </dl>
		/// </summary>
		public string SpyeeChannelStateDesc { get; set; }

		/// <summary>
		/// The caller*ID number of the spyee.
		/// </summary>
		public string SpyeeCallerIdNum { get; set; }

		/// <summary>
		/// The caller*ID name of the spyee.
		/// </summary>
		public string SpyeeCallerIdName { get; set; }

		/// <summary>
		///  Spyee connected line number.
		/// </summary>
		public string SpyeeConnectedLineNum { get; set; }

		/// <summary>
		/// Spyee connected line name.
		/// </summary>
		public string SpyeeConnectedLineName { get; set; }

		/// <summary>
		/// Spyee account code.
		/// </summary>
		public string SpyeeAccountCode { get; set; }

		/// <summary>
		/// Spyee context.
		/// </summary>
		public string SpyeeContext { get; set; }

		/// <summary>
		/// Spyee exten.
		/// </summary>
		public string SpyeeExten { get; set; }

		/// <summary>
		/// Spyee priority.
		/// </summary>
		public string SpyeePriority { get; set; }

		/// <summary>
		/// Spyee uniqueId
		/// </summary>
		public string SpyeeUniqueId { get; set; }

		/// <summary>
		/// Spyee linkedId.
		/// </summary>
		public string SpyeeLinkedId { get; set; }
	}
}