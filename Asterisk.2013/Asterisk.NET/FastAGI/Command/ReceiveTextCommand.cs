namespace Asterisk.NET.FastAGI.Command
{
	/// <summary>
	/// Receives a string of text on a channel.<br/>
	/// Specify timeout to be the maximum time to wait for input in milliseconds, or
	/// 0 for infinite.<br/>
	/// Most channels do not support the reception of text.<br/>
	/// Returns -1 for failure or 1 for success, and the string in parentheses.<br/>
	/// Available since Asterisk 1.2.
	/// </summary>
	public class ReceiveTextCommand : AGICommand
	{
		/// <summary>
		/// The milliseconds to wait for the channel to receive a character.
		/// </summary>
		private int timeout;

		/// <summary>
		/// Creates a new ReceiveTextCommand with a default timeout of 0 meaning to wait for ever.
		/// </summary>
		public ReceiveTextCommand()
		{
			this.timeout = 0;
		}

		/// <summary>
		/// Creates a new ReceiveTextCommand.
		/// <param name=timeout>the milliseconds to wait for the channel to receive the text.</param>
		/// </summary>
		public ReceiveTextCommand(int timeout)
		{
			this.timeout = timeout;
		}

		/// <summary>
		/// Get/Set the milliseconds to wait for the channel to receive the text.
		/// </summary>
		public int Timeout
		{
			get { return timeout; }
			set { this.timeout = value; }
		}

		public override string BuildCommand()
		{
			return "RECEIVE TEXT " + timeout;
		}
	}
}
