using System;
namespace Asterisk.NET.FastAGI.Command
{
	/// <summary>
	/// Turns off music on hold on the current channel.<br/>
	/// Always returns 0.
	/// </summary>
	public class SetMusicOffCommand : AGICommand
	{
		/// <summary> Creates a new SetMusicOffCommand.</summary>
		public SetMusicOffCommand()
		{
		}

		public override string BuildCommand()
		{
			return "SET MUSIC OFF";
		}
	}
}