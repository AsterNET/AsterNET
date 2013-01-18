using System;
using System.Text;

namespace Asterisk.NET.FastAGI.Command
{
	/// <summary>
	/// Plays the given file, allowing playback to be interrupted by the given
	/// digits, if any, and allows the listner to control the stream.<br/>
	/// If offset is provided then the audio will seek to sample offset before play
	/// starts.<br/>
	/// Returns 0 if playback completes without a digit being pressed, or the ASCII
	/// numerical value of the digit if one was pressed, or -1 on error or if the
	/// channel was disconnected. <br/>
	/// Remember, the file extension must not be included in the filename.<br/>
	/// Available since Asterisk 1.2
	/// </summary>
	public class ControlStreamFileCommand : AGICommand
	{
		/// <summary> The name of the file to stream.</summary>
		private string file;
		/// <summary> When one of these digits is pressed while streaming the command returns.</summary>
		private string escapeDigits;
		/// <summary> The offset samples to skip before streaming.</summary>
		private int offset;
		private string forwardDigit;
		private string rewindDigit;
		private string pauseDigit;

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
		#region EscapeDigits
		/// <summary>
		/// Get/Set the digits that allow the user to interrupt this command or <code>null</code> for none.
		/// </summary>
		public string EscapeDigits
		{
			get { return escapeDigits; }
			set { this.escapeDigits = value; }
		}
		#endregion
		#region Offset
		/// <summary>
		/// Get/Set the offset samples to skip before streaming.
		/// </summary>
		public int Offset
		{
			get { return offset; }
			set { this.offset = value; }
		}
		#endregion
		#region ForwardDigit
		/// <summary>
		/// Get the digit for fast forward.
		/// </summary>
		public string ForwardDigit
		{
			get { return forwardDigit; }
		}
		#endregion
		#region RewindDigit
		/// <summary>
		/// Get the digit for rewind.
		/// </summary>
		public string RewindDigit
		{
			get { return rewindDigit; }
		}
		#endregion
		#region PauseDigit
		/// <summary>
		/// Get the digit for pause and unpause.
		/// </summary>
		public string PauseDigit
		{
			get { return pauseDigit; }
		}
		#endregion

		#region ControlStreamFileCommand(string file)
		/// <summary>
		/// Creates a new ControlStreamFileCommand, streaming from the beginning. It
		/// uses the default digit "#" for forward and "*" for rewind and does not
		/// support pausing.
		/// </summary>
		/// <param name="file">the name of the file to stream, must not include extension.</param>
		public ControlStreamFileCommand(string file)
		{
			this.file = file;
			this.escapeDigits = null;
			this.offset = - 1;
		}
		#endregion
		#region ControlStreamFileCommand(string file, string escapeDigits)
		/// <summary>
		/// Creates a new ControlStreamFileCommand, streaming from the beginning. It
		/// uses the default digit "#" for forward and "*" for rewind and does not
		/// support pausing.
		/// </summary>
		/// <param name="file">the name of the file to stream, must not include extension.</param>
		/// <param name="escapeDigits">contains the digits that allow the user to interrupt this command.</param>
		public ControlStreamFileCommand(string file, string escapeDigits)
		{
			this.file = file;
			this.escapeDigits = escapeDigits;
			this.offset = - 1;
		}
		#endregion
		#region ControlStreamFileCommand(string file, string escapeDigits, int offset)
		/// <summary>
		/// Creates a new ControlStreamFileCommand, streaming from the given offset.
		/// It uses the default digit "#" for forward and "*" for rewind and does not
		/// support pausing.
		/// </summary>
		/// <param name="file">the name of the file to stream, must not include extension.</param>
		/// <param name="escapeDigits">
		/// contains the digits that allow the user to interrupt this command.
		/// Maybe <code>null</code> if you don't want the user to interrupt.
		/// </param>
		/// <param name="offset">the offset samples to skip before streaming.</param>
		public ControlStreamFileCommand(string file, string escapeDigits, int offset)
		{
			this.file = file;
			this.escapeDigits = escapeDigits;
			this.offset = offset;
		}
		#endregion
		#region ControlStreamFileCommand(string file, string escapeDigits, int offset, string forwardDigit, string rewindDigit, string pauseDigit)
		/// <summary>
		/// Creates a new ControlStreamFileCommand, streaming from the given offset.
		/// It uses the default digit "#" for forward and "*" for rewind and does not
		/// support pausing.
		/// </summary>
		/// <param name="file">the name of the file to stream, must not include extension.</param>
		/// <param name="escapeDigits">contains the digits that allow the user to interrupt this command. Maybe <code>null</code> if you don't want the user to interrupt.</param>
		/// <param name="offset">the offset samples to skip before streaming.</param>
		/// <param name="forwardDigit">the digit for fast forward.</param>
		/// <param name="rewindDigit">the digit for rewind.</param>
		/// <param name="pauseDigit">the digit for pause and unpause.</param>
		public ControlStreamFileCommand(string file, string escapeDigits, int offset, string forwardDigit, string rewindDigit, string pauseDigit)
		{
			this.file = file;
			this.escapeDigits = escapeDigits;
			this.offset = offset;
			this.forwardDigit = forwardDigit;
			this.rewindDigit = rewindDigit;
			this.pauseDigit = pauseDigit;
		}
		#endregion

		#region ControlDigits(string forwardDigit, string rewindDigit)
		/// <summary>
		/// Sets the control digits for fast forward and rewind.
		/// </summary>
		/// <param name="forwardDigit">the digit for fast forward.</param>
		/// <param name="rewindDigit">the digit for rewind.</param>
		public void  ControlDigits(string forwardDigit, string rewindDigit)
		{
			this.forwardDigit = forwardDigit;
			this.rewindDigit = rewindDigit;
		}
		#endregion
		#region ControlDigits(string forwardDigit, string rewindDigit, string pauseDigit)
		/// <summary>
		/// Sets the control digits for fast forward, rewind and pause.
		/// </summary>
		/// <param name="forwardDigit">the digit for fast forward.</param>
		/// <param name="rewindDigit">the digit for rewind.</param>
		/// <param name="pauseDigit">the digit for pause and unpause.</param>
		public void ControlDigits(string forwardDigit, string rewindDigit, string pauseDigit)
		{
			this.forwardDigit = forwardDigit;
			this.rewindDigit = rewindDigit;
			this.pauseDigit = pauseDigit;
		}
		#endregion

		#region BuildCommand()
		public override string BuildCommand()
		{
			StringBuilder sb = new StringBuilder("CONTROL STREAM FILE ");
			sb.Append(EscapeAndQuote(file) + " " + EscapeAndQuote(escapeDigits));
			if (offset >= 0)
				sb.Append(" " + offset.ToString());
			else if (forwardDigit != null || rewindDigit != null || pauseDigit != null)
				sb.Append(" 0");
			if (forwardDigit != null || rewindDigit != null || pauseDigit != null)
				sb.Append(" " + forwardDigit);
			if (rewindDigit != null || pauseDigit != null)
				sb.Append(" " + rewindDigit);
			if (pauseDigit != null)
				sb.Append(" " + pauseDigit);
			return sb.ToString();
		}
		#endregion
	}
}