using System;
namespace Asterisk.NET.FastAGI.Command
{
	#region Class - VerboseCommand
	/// <summary>
	/// Sends a message to the console via the verbose message system.<br/>
	/// Always returns 1.
	/// </summary>
	public class VerboseCommand : AGICommand
	{
		#region Variables
		/// <summary> The message to send.</summary>
		private string message;
		/// <summary> The verbosity level to use.<br/>
		/// Must be in [1..4]
		/// </summary>
		private int level;
		#endregion

		#region Message
		/// <summary>
		/// Get/Set the message to send.
		/// </summary>
		public string Message
		{
			get { return message; }
			set { this.message = value; }
		}
		#endregion
		#region Level
		/// <summary>
		/// Get/Set the level to use.
		/// </summary>
		/// <throws>  IllegalArgumentException if level is not in [1..4] </throws>
		public int Level
		{
			get { return level; }
			set
			{
				if (value < 1 || value > 4)
				{
					throw new ArgumentException("level must be in [1..4]");
				}
				this.level = value;
			}
		}
		#endregion

		#region Constructor - VerboseCommand(string message, int level)
		/// <summary>
		/// Creates a new VerboseCommand.
		/// </summary>
		/// <param name="message">the message to send.</param>
		/// <param name="level">the verbosity level to use. Must be in [1..4]</param>
		/// <throws>  IllegalArgumentException if level is not in [1..4] </throws>
		public VerboseCommand(string message, int level)
		{
			this.Message = message;
			this.Level = level;
		}
		#endregion

		#region BuildCommand()
		public override string BuildCommand()
		{
			return "VERBOSE " + EscapeAndQuote(message) + " " + level;
		}
		#endregion
	}
	#endregion
}