namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A ZapShowChannelsEvent is triggered in response to a ZapShowChannelsAction and shows the state of a zap channel.
	/// </summary>
	/// <seealso cref="Manager.Action.ZapShowChannelsAction" />
	public class ZapShowChannelsEvent : ResponseEvent
	{
		private string signalling;
		private string context;
		private string alarm;

		/// <summary>
		/// Get/Set the signalling of this zap channel.<br/>
		/// Possible values are:
		/// <ul>
		/// <li>E & M Immediate</li>
		/// <li>E & M Wink</li>
		/// <li>E & M E1</li>
		/// <li>Feature Group D (DTMF)</li>
		/// <li>Feature Group D (MF)</li>
		/// <li>Feature Group B (MF)</li>
		/// <li>E911 (MF)</li>
		/// <li>FXS Loopstart</li>
		/// <li>FXS Groundstart</li>
		/// <li>FXS Kewlstart</li>
		/// <li>FXO Loopstart</li>
		/// <li>FXO Groundstart</li>
		/// <li>FXO Kewlstart</li>
		/// <li>PRI Signalling</li>
		/// <li>R2 Signalling</li>
		/// <li>SF (Tone) Signalling Immediate</li>
		/// <li>SF (Tone) Signalling Wink</li>
		/// <li>SF (Tone) Signalling with Feature Group D (DTMF)</li>
		/// <li>SF (Tone) Signalling with Feature Group D (MF)</li>
		/// <li>SF (Tone) Signalling with Feature Group B (MF)</li>
		/// <li>GR-303 Signalling with FXOKS</li>
		/// <li>GR-303 Signalling with FXSKS</li>
		/// <li>Pseudo Signalling</li>
		/// </ul>
		/// </summary>
		public string Signalling
		{
			get { return signalling; }
			set { this.signalling = value; }
		}
		/// <summary>
		/// Get/Set the context of this zap channel as defined in <code>zapata.conf</code>.
		/// </summary>
		public string Context
		{
			get { return context; }
			set { this.context = value; }
		}
		/// <summary>
		/// Get/Set the alarm state of this zap channel.<br/>
		/// This may be one of
		/// <ul>
		/// <li>Red Alarm</li>
		/// <li>Yellow Alarm</li>
		/// <li>Blue Alarm</li>
		/// <li>Recovering</li>
		/// <li>Loopback</li>
		/// <li>Not Open</li>
		/// <li>No Alarm</li>
		/// </ul>
		/// </summary>
		public string Alarm
		{
			get { return alarm; }
			set { this.alarm = value; }
		}

		public ZapShowChannelsEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}