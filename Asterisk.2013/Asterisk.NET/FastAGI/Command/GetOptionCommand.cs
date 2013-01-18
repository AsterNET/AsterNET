using System;
namespace Asterisk.NET.FastAGI.Command
{
	/// <summary>
	/// Plays the given file, and waits for the user to press one of the given
	/// digits. If none of the esacpe digits is pressed while streaming the file this
	/// command waits for the specified timeout still waiting for the user to press a
	/// digit. Streaming always begins at the beginning.<br/>
	/// Returns 0 if no digit being pressed, or the ASCII numerical value of the
	/// digit if one was pressed, or -1 on error or if the channel was disconnected.
	/// <br/>
	/// Remember, the file extension must not be included in the filename.
	/// </summary>
	/// <seealso cref="FastAGI.Command.StreamFileCommand" />
	public class GetOptionCommand : AGICommand
	{
		/// <summary> The name of the file to stream.</summary>
		private string file;
		/// <summary> When one of these digits is pressed while streaming the command returns.</summary>
		private string escapeDigits;
		/// <summary> The timeout in seconds.</summary>
		private int timeout;

		/// <summary>
		/// Get/Set the name of the file to stream.
		/// </summary>
		public string File
		{
			get { return file; }
			set { this.file = value; }
		}
		/// <summary>
		/// Get/Set the digits that the user is expected to press.
		/// </summary>
		public string EscapeDigits
		{
			get { return escapeDigits; }
			set { this.escapeDigits = value; }
		}
		/// <summary>
		/// Get/Set the timeout to wait if none of the defined esacpe digits was presses while streaming.
		/// </summary>
		public int Timeout
		{
			get { return timeout; }
			set { this.timeout = value; }
		}
		
		/// <summary>
		/// Creates a new GetOptionCommand with a default timeout of 5 seconds.
		/// </summary>
		/// <param name="file">the name of the file to stream, must not include extension.</param>
		/// <param name="escapeDigits">contains the digits that the user is expected to press.</param>
		public GetOptionCommand(string file, string escapeDigits)
		{
			this.file = file;
			this.escapeDigits = escapeDigits;
			this.timeout = - 1;
		}
		
		/// <summary>
		/// Creates a new GetOptionCommand with the given timeout.
		/// </summary>
		/// <param name="file">the name of the file to stream, must not include extension.</param>
		/// <param name="escapeDigits">contains the digits that the user is expected to press.</param>
		/// <param name="timeout">the timeout in seconds to wait if none of the defined esacpe digits was presses while streaming.</param>
		public GetOptionCommand(string file, string escapeDigits, int timeout)
		{
			this.file = file;
			this.escapeDigits = escapeDigits;
			this.timeout = timeout;
		}
		
		public override string BuildCommand()
		{
			return "GET OPTION " + EscapeAndQuote(file) + " " + EscapeAndQuote(escapeDigits) + (timeout < 0?"":" " + timeout);
		}
	}
}