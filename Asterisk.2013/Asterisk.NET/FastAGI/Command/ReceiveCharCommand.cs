using System;
namespace Asterisk.NET.FastAGI.Command
{
	/// <summary>
	/// Receives a character of text on a channel.<br/>
	/// Specify timeout to be the maximum time to wait for input in milliseconds, or 0 for infinite.<br/>
	/// Most channels do not support the reception of text.<br/>
	/// Returns the decimal value of the character if one is received, or 0 if the
	/// channel does not support text reception. Returns -1 only on error/hangup.
	/// </summary>
	public class ReceiveCharCommand : AGICommand
	{
		/// <summary> The milliseconds to wait for the channel to receive a character.</summary>
		private int timeout;

		/// <summary>
		/// Get/Set the milliseconds to wait for the channel to receive a character.
		/// </summary>
		public int Timeout
		{
			get { return timeout; }
			set { this.timeout = value; }
		}
		
		/// <summary>
		/// Creates a new ReceiveCharCommand with a default timeout of 0 meaning to wait for ever.
		/// </summary>
		public ReceiveCharCommand()
		{
			this.timeout = 0;
		}
		
		/// <summary>
		/// Creates a new ReceiveCharCommand.
		/// </summary>
		/// <param name="timeout">the milliseconds to wait for the channel to receive a character.</param>
		public ReceiveCharCommand(int timeout)
		{
			this.timeout = timeout;
		}
		
		public override string BuildCommand()
		{
			return "RECEIVE CHAR " + timeout;
		}
	}
}