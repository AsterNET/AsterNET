using System;
namespace Asterisk.NET.FastAGI.Command
{
	/// <summary>
	/// Say a given number, returning early if any of the given DTMF number are received on the channel.<br/>
	/// Returns 0 if playback completes without a digit being pressed, or the ASCII
	/// numerical value of the digit if one was pressed or -1 on error/hangup.
	/// </summary>
	public class SayNumberCommand : AGICommand
	{
		/// <summary> The number to say.</summary>
		private string number;
		/// <summary> When one of these number is pressed while streaming the command returns.</summary>
		private string escapeDigits;

		/// <summary>
		/// Get/Set the number to say.
		/// </summary>
		public string Number
		{
			get { return number; }
			set { this.number = value; }
		}
		/// <summary>
		/// Get/Set the number that allow the user to interrupt this command.
		/// </summary>
		public string EscapeDigits
		{
			get { return escapeDigits; }
			set { this.escapeDigits = value; }
		}
		
		/// <summary>
		/// Creates a new SayNumberCommand.
		/// </summary>
		/// <param name="number">the number to say.</param>
		public SayNumberCommand(string number)
		{
			this.number = number;
			this.escapeDigits = null;
		}
		
		/// <summary>
		/// Creates a new SayNumberCommand.
		/// </summary>
		/// <param name="number">the number to say.</param>
		/// <param name="escapeDigits">contains the number that allow the user to interrupt this command.</param>
		public SayNumberCommand(string number, string escapeDigits)
		{
			this.number = number;
			this.escapeDigits = escapeDigits;
		}
		
		public override string BuildCommand()
		{
			return "SAY NUMBER " + EscapeAndQuote(number) + " " + EscapeAndQuote(escapeDigits);
		}
	}
}