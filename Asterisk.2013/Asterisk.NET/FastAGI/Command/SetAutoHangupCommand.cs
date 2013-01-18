using System;
namespace Asterisk.NET.FastAGI.Command
{
	/// <summary>
	/// Cause the channel to automatically hangup at the given number of seconds in the future.<br/>
	/// Of course it can be hungup before then as well. Setting to 0 will cause the
	/// autohangup feature to be disabled on this channel.
	/// </summary>
	public class SetAutoHangupCommand : AGICommand
	{
		/// <summary> The number of seconds before this channel is automatically hung up.</summary>
		private int time;

		/// <summary>
		/// Get/Set the number of seconds before this channel is automatically hung up.
		/// </summary>
		/// <returns>the number of seconds before this channel is automatically hung up.</returns>
		/// <param name="time">
		/// the number of seconds before this channel is automatically hung up.<br/>
		/// 0 disables the autohangup feature.
		/// </param>
		public int Time
		{
			get { return time; }
			set { this.time = value; }
		}
		
		/// <summary>
		/// Creates a new SetAutoHangupCommand.
		/// </summary>
		/// <param name="time">
		/// the number of seconds before this channel is automatically hung up.<br/>
		/// 0 disables the autohangup feature.
		/// </param>
		public SetAutoHangupCommand(int time)
		{
			this.time = time;
		}
		
		public override string BuildCommand()
		{
			return "SET AUTOHANGUP " + time;
		}
	}
}