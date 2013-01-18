using System;
namespace Asterisk.NET.FastAGI.Command
{
	/// <summary>
	/// Sends the given text on a channel.<br/>
	/// Most channels do not support the transmission of text.<br/>
	/// Returns 0 if text is sent, or if the channel does not support text
	/// transmission. Returns -1 only on error/hangup.
	/// </summary>
	public class SendTextCommand : AGICommand
	{
		/// <summary> The text to send.</summary>
		private string text;

		/// <summary>
		/// Get/Set the text to send.
		/// </summary>
		/// <param name="text">the text to send.</param>
		/// <returns>the text to send.</returns>
		public string Text
		{
			get { return text; }
			set { this.text = value; }
		}
		
		/// <summary>
		/// Creates a new SendTextCommand.
		/// </summary>
		/// <param name="text">the text to send.</param>
		public SendTextCommand(string text)
		{
			this.text = text;
		}
		
		public override string BuildCommand()
		{
			return "SEND TEXT " + EscapeAndQuote(text);
		}
	}
}