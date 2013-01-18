using System;

namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// The ZapDNDOnAction switches a zap channel "Do Not Disturb" status off.
	/// </summary>
	public class ZapDNDOffAction : ManagerAction
	{
		private int zapChannel;

		/// <summary>
		/// Get the name of this action, i.e. "ZapDNDOff".
		/// </summary>
		override public string Action
		{
			get { return "ZapDNDOff"; }
		}
		/// <summary>
		/// Get/Set the number of the zap channel to switch to dnd off.<br/>
		/// This property is mandatory.
		/// </summary>
		public int ZapChannel
		{
			get { return this.zapChannel; }
			set { this.zapChannel = value; }
		}
		/// <summary>
		/// Creates a new empty ZapDNDOffAction.
		/// </summary>
		public ZapDNDOffAction()
		{
		}
		/// <summary>
		/// Creates a new ZapDNDOffAction that disables "Do Not Disturb" status for the given zap channel.
		/// </summary>
		public ZapDNDOffAction(int zapChannel)
		{
			this.zapChannel = zapChannel;
		}
	}
}