using System;
namespace Asterisk.NET.FastAGI.Command
{
	/// <summary>
	/// Turns on music on hold on the current channel.<br/>
	/// Always returns 0.
	/// </summary>
	public class SetMusicOnCommand : AGICommand
	{
		/// <summary>
		/// Get/Set the music on hold class to play music from.
		/// </summary>
		/// <returns>the music on hold class to play music from or <code>null</code> for the default class.</returns>
		/// <param name="musicOnHoldClass">the music on hold class to play music from or <code>null</code> for the default class.</param>
		public string MusicOnHoldClass
		{
			get { return musicOnHoldClass; }
			set { this.musicOnHoldClass = value; }
		}
		
		/// <summary> The music on hold class to play music from.</summary>
		private string musicOnHoldClass;
		
		/// <summary> Creates a new SetMusicOnCommand playing music from the default music on hold class.</summary>
		public SetMusicOnCommand()
		{
			this.musicOnHoldClass = null;
		}
		
		/// <summary>
		/// Creates a new SetMusicOnCommand playing music from the default music on hold class.
		/// </summary>
		/// <param name="musicOnHoldClass">the music on hold class to play music from.</param>
		public SetMusicOnCommand(string musicOnHoldClass)
		{
			this.musicOnHoldClass = musicOnHoldClass;
		}
		
		public override string BuildCommand()
		{
			return "SET MUSIC ON" + (musicOnHoldClass == null?"":" " + EscapeAndQuote(musicOnHoldClass));
		}
	}
}