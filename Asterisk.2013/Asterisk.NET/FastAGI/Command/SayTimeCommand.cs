using System;
namespace Asterisk.NET.FastAGI.Command
{
	/// <summary>
	/// Say a given time, returning early if any of the given DTMF digits are received on the channel.<br/>
	/// Time is the number of seconds elapsed since 00:00:00 on January 1, 1970, Coordinated Universal Time (UTC).<br/>
	/// Returns 0 if playback completes without a digit being pressed, or the ASCII
	/// numerical value of the digit if one was pressed or -1 on error/hangup.
	/// </summary>
	public class SayTimeCommand : AGICommand
	{
		/// <summary> The time to say in seconds since 00:00:00 on January 1, 1970.</summary>
		private long time;
		/// <summary> When one of these digits is pressed the command returns.</summary>
		private string escapeDigits;

		/// <summary>
		/// Get/Set the time to say in seconds since 00:00:00 on January 1, 1970.
		/// </summary>
		public long Time
		{
			get { return time; }
			set { this.time = value; }
		}
		/// <summary>
		/// Get/Set the digits that allow the user to interrupt this command.
		/// </summary>
		public string EscapeDigits
		{
			get { return escapeDigits; }
			set { this.escapeDigits = value; }
		}
		
		/// <summary>
		/// Creates a new SayTimeCommand.
		/// </summary>
		/// <param name="time">the time to say in seconds since 00:00:00 on January 1, 1970.</param>
		public SayTimeCommand(long time)
		{
			this.time = time;
			this.escapeDigits = null;
		}
		
		/// <summary>
		/// Creates a new SayTimeCommand.
		/// </summary>
		/// <param name="time">the time to say in seconds since 00:00:00 on January 1, 1970.</param>
		/// <param name="escapeDigits">contains the digits that allow the user to interrupt this command.</param>
		public SayTimeCommand(long time, string escapeDigits)
		{
			this.time = time;
			this.escapeDigits = escapeDigits;
		}
		
		public override string BuildCommand()
		{
			return "SAY TIME " + time + " " + EscapeAndQuote(escapeDigits);
		}
	}
}