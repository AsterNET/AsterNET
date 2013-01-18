using System;

namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// The ZapHangupAction hangs up a zap channel.
	/// </summary>
	public class ZapHangupAction : ManagerAction
	{
		private int zapChannel;

		/// <summary>
		/// Get the name of this action, i.e. "ZapHangup".
		/// </summary>
		override public string Action
		{
			get { return "ZapHangup"; }
		}
		/// <summary>
		/// Get/Set the number of the zap channel to hangup.<br/>
		/// This property is mandatory.
		/// </summary>
		public int ZapChannel
		{
			get { return this.zapChannel; }
			set { this.zapChannel = value; }
		}
		
		/// <summary>
		/// Creates a new empty ZapHangupAction.
		/// </summary>
		public ZapHangupAction()
		{
		}
		
		/// <summary>
		/// Creates a new ZapHangupAction that hangs up the given zap channel (the number of the zap channel to hang up).
		/// </summary>
		public ZapHangupAction(int zapChannel)
		{
			this.zapChannel = zapChannel;
		}
	}
}