using System.Text;
namespace Asterisk.NET.FastAGI.Command
{
	/// <summary>
	/// Say a given time, returning early if any of the given DTMF digits are pressed.<br/>
	/// Returns 0 if playback completes without a digit being pressed, or the ASCII
	/// numerical value of the digit if one was pressed or -1 on error/hangup.<br/>
	/// Available since Asterisk 1.2.
	/// </summary>
	public class SayDateTimeCommand : AGICommand
	{
		private static string DEFAULT_FORMAT = "ABdY 'digits/at' IMp";

		private long time;
		private string escapeDigits;
		private string format;
		private string timezone;

		/// <summary>
		/// Creates a new SayDateTimeCommand that says the given time.
		/// <param name="time">the time to say in seconds elapsed since 00:00:00 on January 1, 1970, Coordinated Universal Time (UTC)</param>
		/// </summary>
		public SayDateTimeCommand(long time)
		{
			this.time = time;
		}

		/// <summary>
		/// Creates a new SayDateTimeCommand that says the given time and allows interruption by one of the given escape digits.
		/// </summary>
		/// <param name="time">the time to say in seconds elapsed since 00:00:00 on January 1, 1970, Coordinated Universal Time (UTC)</param>
		/// <param name="escapeDigits">the digits that allow the user to interrupt this command or <code>null</code> for none.</param>
		public SayDateTimeCommand(long time, string escapeDigits)
		{
			this.time = time;
			this.escapeDigits = escapeDigits;
		}

		/// <summary>
		/// Creates a new SayDateTimeCommand that says the given time in the given
		/// format and allows interruption by one of the given escape digits.
		/// </summary>
		/// <param name="time">the time to say in seconds elapsed since 00:00:00 on January 1, 1970, Coordinated Universal Time (UTC)</param>
		/// <param name="escapeDigits">the digits that allow the user to interrupt this command or <code>null</code> for none.</param>
		/// <param name="format">the format the time should be said in</param>
		public SayDateTimeCommand(long time, string escapeDigits, string format)
		{
			this.time = time;
			this.escapeDigits = escapeDigits;
			this.format = format;
		}

		/// <summary>
		/// Creates a new SayDateTimeCommand that says the given time in the given
		/// format and timezone and allows interruption by one of the given escape
		/// digits.
		/// </summary>
		/// <param name="time">the time to say in seconds elapsed since 00:00:00 on January 1, 1970, Coordinated Universal Time (UTC)</param>
		/// <param name="escapeDigits">the digits that allow the user to interrupt this command or <code>null</code> for none.</param>
		/// <param name="format">the format the time should be said in</param>
		/// <param name="timezone">the timezone to use when saying the time, for example "UTC" or "Europe/Berlin".</param>
		public SayDateTimeCommand(long time, string escapeDigits, string format, string timezone)
		{
			this.time = time;
			this.escapeDigits = escapeDigits;
			this.format = format;
			this.timezone = timezone;
		}

		/// <summary>
		/// Get/Set the time to say in seconds elapsed since 00:00:00 on January 1, 1970, Coordinated Universal Time (UTC).
		/// </summary>
		public long Time
		{
			get { return this.time; }
			set { this.time = value; }
		}

		/// <summary>
		/// Get/Set the digits that allow the user to interrupt this command.
		/// </summary>
		public string getEscapeDigits
		{
			get { return this.escapeDigits; }
			set { this.escapeDigits = value; }
		}

		/// <summary>
		/// Get/Set the format the time should be said in.
		/// </summary>
		public string Format
		{
			get { return this.format; }
			set { this.format = value; }
		}

		/// <summary>
		/// Get/Set the timezone to use when saying the time.
		/// </summary>
		public string Timezone
		{
			get { return this.timezone; }
			set { this.timezone = value; }
		}

		public override string BuildCommand()
		{
			StringBuilder sb = new StringBuilder("SAY DATETIME ");
			sb.Append(time);
			sb.Append(" ");
			sb.Append(EscapeAndQuote(escapeDigits));

			if (format == null && timezone != null)
			{
				sb.Append(" ");
				sb.Append(EscapeAndQuote(DEFAULT_FORMAT));
			}
			if (format != null)
			{
				sb.Append(" ");
				sb.Append(EscapeAndQuote(format));
			}

			if (timezone != null)
			{
				sb.Append(" ");
				sb.Append(EscapeAndQuote(timezone));
			}
			return sb.ToString();
		}
	}

}