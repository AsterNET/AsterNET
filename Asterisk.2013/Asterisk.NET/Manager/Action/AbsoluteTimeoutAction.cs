using System;

namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// The AbsoluteTimeoutAction sets the absolute maximum amount of time permitted for a call on a given channel.<br/>
	/// Note that the timeout is set from the current time forward, not counting the number of seconds the call has already been up.<br/>
	/// When setting a new timeout all previous absolute timeouts are cancelled.<br/>
	/// When the timeout is reached the call is returned to the T extension so that
	/// you can playback an explanatory note to the calling party (the called party will not hear that).<br/>
	/// This action corresponds the the AbsoluteTimeout command used in the dialplan.
	/// </summary>
	public class AbsoluteTimeoutAction : ManagerAction
	{
		private string channel;
		private int timeout;

		#region AbsoluteTimeoutAction()
		/// <summary>
		/// Creates a new empty AbsoluteTimeoutAction.
		/// </summary>
		public AbsoluteTimeoutAction()
		{
		}
		#endregion
		#region AbsoluteTimeoutAction(channel, timeout)
		/// <summary>
		/// Creates a new AbsoluteTimeoutAction with the given channel and timeout.
		/// </summary>
		/// <param name="channel">the name of the channel</param>
		/// <param name="timeout">the timeout in seconds or 0 to cancel the AbsoluteTimeout</param>
		public AbsoluteTimeoutAction(string channel, int timeout)
		{
			this.channel = channel;
			this.timeout = timeout;
		}
		#endregion

		#region Action
		/// <summary>
		/// Get the name of this action, i.e. "AbsoluteTimeout".
		/// </summary>
		override public string Action
		{
			get { return "AbsoluteTimeout"; }
		}
		#endregion
		#region Channel
		/// <summary>
		/// Get/Set the name of the channel.</summary>
		public string Channel
		{
			get { return channel; }
			set { this.channel = value; }
		}
		#endregion
		#region Timeout
		/// <summary>
		/// Get/Set the timeout (in seconds) to set.
		/// </summary>
		public int Timeout
		{
			get { return timeout; }
			set { this.timeout = value; }
		}
		#endregion
	}
}