using System;
namespace Asterisk.NET.FastAGI.Command
{
	/// <summary>
	/// Record to a file until a given dtmf digit in the sequence is received.<br/>
	/// Returns -1 on hangup or error.<br/>
	/// The format will specify what kind of file will be recorded. The timeout is
	/// the maximum record time in milliseconds, or -1 for no timeout. Offset samples
	/// is optional, and if provided will seek to the offset without exceeding the
	/// end of the file. "maxSilence" is the number of seconds of maxSilence allowed
	/// before the function returns despite the lack of dtmf digits or reaching
	/// timeout.
	/// </summary>
	public class RecordFileCommand : AGICommand
	{
		#region Variables
		/// <summary> The name of the file to record.</summary>
		private string file;
		/// <summary> The format of the file to be recorded, for example "wav".</summary>
		private string format;
		/// <summary> The these digits a user can press to end the recording.</summary>
		private string escapeDigits;
		/// <summary> The maximum record time in milliseconds, or -1 for no timeout.</summary>
		private int timeout;
		/// <summary> The offset samples to skip.</summary>
		private int offset;
		/// <summary> Wheather a beep should be played before recording.</summary>
		private bool beep;
		/// <summary> The amount of silence (in seconds) to allow before returning despite the lack of dtmf digits or reaching timeout.</summary>
		private int maxSilence;
		#endregion

		#region File
		/// <summary>
		/// Get/Set the name of the file to stream.
		/// </summary>
		public string File
		{
			get { return file; }
			set { this.file = value; }
		}
		#endregion
		#region Format
		/// <summary>
		/// Get/Set the format of the file to be recorded, for example "wav".
		/// </summary>
		public string Format
		{
			get { return format; }
			set { this.format = value; }
		}
		#endregion
		#region EscapeDigits
		/// <summary>
		/// Get/Set the digits that allow the user to end recording.
		/// </summary>
		public string EscapeDigits
		{
			get { return escapeDigits; }
			set { this.escapeDigits = value; }
		}
		#endregion
		#region Timeout
		/// <summary>
		/// Get/Set the maximum record time in milliseconds, or -1 for no timeout.
		/// </summary>
		public int Timeout
		{
			get { return timeout; }
			set { this.timeout = value; }
		}
		#endregion
		#region Offset
		/// <summary>
		/// Get/Set the offset samples to skip.
		/// </summary>
		public int Offset
		{
			get { return offset; }
			set { this.offset = value; }
		}
		#endregion
		#region Beep
		/// <summary>
		/// Get/Set <code>true</code> if a beep should be played before recording. <code>false</code> if not.
		/// </summary>
		public bool Beep
		{
			get { return beep; }
			set { this.beep = value; }
		}
		#endregion

		#region Constructor - RecordFileCommand(string file, string format, string escapeDigits, int timeout)
		/// <summary>
		/// Creates a new RecordFileCommand.
		/// </summary>
		/// <param name="file">the name of the file to stream, must not include extension.</param>
		/// <param name="format">the format of the file to be recorded, for example "wav".</param>
		/// <param name="escapeDigits">contains the digits that allow the user to end recording.</param>
		/// <param name="timeout">the maximum record time in milliseconds, or -1 for no timeout.</param>
		public RecordFileCommand(string file, string format, string escapeDigits, int timeout)
		{
			this.file = file;
			this.format = format;
			this.escapeDigits = escapeDigits;
			this.timeout = timeout;
			this.offset = 0;
			this.beep = false;
			this.maxSilence = 0;
		}
		#endregion
		#region Constructor - RecordFileCommand(string file, string format, string escapeDigits, int timeout)
		/// <summary>
		/// Creates a new RecordFileCommand.
		/// </summary>
		/// <param name="file">the name of the file to stream, must not include extension.</param>
		/// <param name="format">the format of the file to be recorded, for example "wav".</param>
		/// <param name="escapeDigits">contains the digits that allow the user to end recording.</param>
		/// <param name="timeout">the maximum record time in milliseconds, or -1 for no timeout.</param>
		/// <param name="offset">the offset samples to skip.</param>
		/// <param name="beep"><code>true</code> if a beep should be played before recording.</param>
		/// <param name="maxSilence">The amount of silence (in seconds) to allow before returning despite the lack of dtmf digits or reaching timeout.</param>
		public RecordFileCommand(string file, string format, string escapeDigits, int timeout, int offset, bool beep, int maxSilence)
		{
			this.file = file;
			this.format = format;
			this.escapeDigits = escapeDigits;
			this.timeout = timeout;
			this.offset = offset;
			this.beep = beep;
			this.maxSilence = maxSilence;
		}
		#endregion

		#region BuildCommand()
		public override string BuildCommand()
		{
			return "RECORD FILE " + EscapeAndQuote(file) + " " + EscapeAndQuote(format) + " " + EscapeAndQuote(escapeDigits) + " " + timeout + " " + offset + (beep == true?" BEEP":"") + " s=" + maxSilence;
		}
		#endregion
	}
}