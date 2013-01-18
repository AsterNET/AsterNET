using System;
namespace Asterisk.NET.FastAGI.Command
{
	/// <summary>
	/// Enable/Disable TDD transmission/reception on a channel.<br/>
	/// Returns 1 if successful, or 0 if channel is not TDD-capable.
	/// </summary>
	public class TDDModeCommand : AGICommand
	{
		private string mode;

		/// <summary>
		/// Get the mode to set.
		/// </summary>
		public string Mode
		{
			get { return mode; }
		}
		/// <summary>
		/// Sets the mode to set. The mode to set, this can be one of "on", "off", "mate" or "tdd".
		/// </summary>
		public string Timeout
		{
			set { this.mode = value; }
		}
		
		/// <summary>
		/// Creates a new TDDModeCommand. The mode to set, this can be one of "on", "off", "mate" or "tdd".
		/// </summary>
		public TDDModeCommand(string mode)
		{
			this.mode = mode;
		}
		
		public override string BuildCommand()
		{
			return "TDD MODE " + EscapeAndQuote(mode);
		}
	}
}