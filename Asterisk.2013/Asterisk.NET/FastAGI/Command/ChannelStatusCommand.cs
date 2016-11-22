using System;
namespace AsterNET.FastAGI.Command
{
    /// <summary>
    /// Returns the status of the specified channel.
    /// If no channel name is given the returns the status of the current channel.<br/>
    /// Return values:
    /// <ul>
    /// <li>0 Channel is down and available</li>
    /// <li>1 Channel is down, but reserved</li>
    /// <li>2 Channel is off hook</li>
    /// <li>3 Digits (or equivalent) have been dialed</li>
    /// <li>4 Line is ringing</li>
    /// <li>5 Remote end is ringing</li>
    /// <li>6 Line is up</li>
    /// <li>7 Line is busy</li>
    /// </ul>
    /// </summary>
    public class ChannelStatusCommand : AGICommand
	{
		private string channel;
		public string Channel
		{
			get
			{
				return channel;
			}
			
			set
			{
				this.channel = value;
			}
			
		}

		public ChannelStatusCommand()
		{
			this.channel = null;
		}
		
		/// <summary>
		/// Creates a new ChannelStatusCommand that queries the given channel.
		/// </summary>
		/// <param name="channel">the name of the channel to query.</param>
		public ChannelStatusCommand(string channel)
		{
			this.channel = channel;
		}

		public override string BuildCommand()
		{
			return "CHANNEL STATUS" + (channel == null ? "" : " " + EscapeAndQuote(channel));
		}
	}
}