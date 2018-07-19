using System;
namespace AspNetCore.AsterNET.FastAGI.Command
{
	
	/// <summary>
	/// Say a given character string with phonetics, returning early if any of the given DTMF digits are received on the channel.<br/>
	/// Returns 0 if playback completes without a digit being pressed, or the ASCII
	/// numerical value of the digit if one was pressed or -1 on error/hangup.
	/// </summary>
	public class SayPhoneticCommand : AGICommand
	{
		/// <summary> The text to say.</summary>
		private string text;
		/// <summary> When one of these digits is pressed the command returns.</summary>
		private string escapeDigits;

		/// <summary>
		/// Get/Set the text to say.
		/// </summary>
		public string Text
		{
			get { return text; }
			set { this.text = value; }
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
		/// Creates a new SayPhonticCommand.
		/// </summary>
		/// <param name="text">the text to say.</param>
		public SayPhoneticCommand(string text)
		{
			this.text = text;
			this.escapeDigits = null;
		}
		
		/// <summary>
		/// Creates a new SayPhoneticCommand.
		/// </summary>
		/// <param name="text">the text to say.</param>
		/// <param name="escapeDigits">contains the digits that allow the user to interrupt this command.</param>
		public SayPhoneticCommand(string text, string escapeDigits)
		{
			this.text = text;
			this.escapeDigits = escapeDigits;
		}
		
		public override string BuildCommand()
		{
			return "SAY PHONETIC " + EscapeAndQuote(text) + " " + EscapeAndQuote(escapeDigits);
		}
	}
}