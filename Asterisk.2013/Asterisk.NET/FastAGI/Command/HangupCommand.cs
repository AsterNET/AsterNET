using System;
namespace Asterisk.NET.FastAGI.Command
{
	/// <summary>
	/// Hangs up the specified channel. If no channel name is given, hangs up the current channel.
	/// </summary>
	public class HangupCommand : AGICommand
	{

		/// <summary>
		/// The name of the channel to hangup or <code>null</code> for the current channel.
		/// </summary>
		private string channel;

		/// <summary>
		/// Returns the name of the channel to hangup.
		/// </summary>
		/// <returns>the name of the channel to hangup or <code>null</code> for the current channel.</returns>
		/// <summary> Sets the name of the channel to hangup.</summary>
		/// <param name="channel">the name of the channel to hangup or <code>null</code> for the current channel.</param>
		public string Channel
		{
			get { return channel; }
			set { this.channel = value; }
		}
		
		/// <summary> Creates a new HangupCommand that hangs up the current channel.</summary>
		public HangupCommand()
		{
			this.channel = null;
		}
		
		/// <summary>
		/// Creates a new HangupCommand that hangs up the given channel.
		/// </summary>
		/// <param name="channel">the name of the channel to hangup.</param>
		public HangupCommand(string channel)
		{
			this.channel = channel;
		}
		
		public override string BuildCommand()
		{
			return "HANGUP" + (channel == null ? "" : " " + EscapeAndQuote(channel));
		}
	}
}