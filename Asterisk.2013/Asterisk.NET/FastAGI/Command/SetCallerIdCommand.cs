using System;
namespace Asterisk.NET.FastAGI.Command
{
	/// <summary>
	/// Changes the CallerID of the current channel.
	/// </summary>
	public class SetCallerIdCommand : AGICommand
	{
		/// <summary> The new callerId.</summary>
		private string callerId;

		/// <summary>
		/// Get/Set the new callerId.
		/// </summary>
		public string CallerId
		{
			get { return callerId; }
			set { this.callerId = value; }
		}
		
		/// <summary>
		/// Creates a new SetCallerIdCommand.
		/// </summary>
		/// <param name="callerId">the new callerId.</param>
		public SetCallerIdCommand(string callerId)
		{
			this.callerId = callerId;
		}
		
		public override string BuildCommand()
		{
			return "SET CALLERID " + EscapeAndQuote(callerId);
		}
	}
}