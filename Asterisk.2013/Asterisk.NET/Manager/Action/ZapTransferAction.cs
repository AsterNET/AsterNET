using System;
namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// The ZapTransferAction transfers a zap channel.
	/// </summary>
	public class ZapTransferAction : ManagerAction
	{
		private int zapChannel;

		/// <summary>
		/// Get the name of this action, i.e. "ZapTransfer".
		/// </summary>
		override public string Action
		{
			get { return "ZapTransfer"; }
		}
		/// <summary>
		/// Get/Set the number of the zap channel to transfer.<br/>
		/// This property is mandatory.
		/// </summary>
		public int ZapChannel
		{
			get { return this.zapChannel; }
			set { this.zapChannel = value; }
		}
	}
}