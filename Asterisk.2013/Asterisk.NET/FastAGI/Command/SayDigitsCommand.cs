using System;
namespace Asterisk.NET.FastAGI.Command
{
	/// <summary>
	/// Say a given digit string, returning early if any of the given DTMF digits are received on the channel.<br/>
	/// Returns 0 if playback completes without a digit being pressed,
	/// or the ASCII numerical value of the digit if one was pressed or -1 on error/hangup.
	/// </summary>
	public class SayDigitsCommand : AGICommand
	{
		#region Variables
		/// <summary> The digits string to say.</summary>
		private string digits;
		/// <summary> When one of these digits is pressed while saying the digits the command returns.</summary>
		private string escapeDigits;
		#endregion

		#region Digits
		/// <summary>
		/// Get/Set the digits string to say.
		/// </summary>
		public string Digits
		{
			get { return digits; }
			set { this.digits = value; }
		}
		#endregion
		#region EscapeDigits
		/// <summary>
		/// Get/Set the digits that allow the user to interrupt this command.
		/// </summary>
		public string EscapeDigits
		{
			get { return escapeDigits; }
			set { this.escapeDigits = value; }
		}
		#endregion

		#region Constructor - SayDigitsCommand(string digits)
		/// <summary>
		/// Creates a new SayDigitsCommand.
		/// </summary>
		/// <param name="digits">the digits to say.</param>
		public SayDigitsCommand(string digits)
		{
			this.digits = digits;
			this.escapeDigits = null;
		}
		#endregion
		#region Constructor - SayDigitsCommand(string digits, string escapeDigits)
		/// <summary>
		/// Creates a new SayDigitsCommand.
		/// </summary>
		/// <param name="digits">the digits to say.</param>
		/// <param name="escapeDigits">the digits that allow the user to interrupt this command.</param>
		public SayDigitsCommand(string digits, string escapeDigits)
		{
			this.digits = digits;
			this.escapeDigits = escapeDigits;
		}
		#endregion

		#region BuildCommand()
		public override string BuildCommand()
		{
			return "SAY DIGITS " + EscapeAndQuote(digits) + " " + EscapeAndQuote(escapeDigits);
		}
		#endregion
	}
}