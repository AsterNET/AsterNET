using System;

namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// The StopMonitorAction ends monitoring (recording) a channel.<br/>
	/// It is implemented in <code>res/res_monitor.c</code>
	/// </summary>
	public class StopMonitorAction : ManagerAction
	{
		/// <summary> The name of the channel to end monitoring.</summary>
		private string channel;

		#region Action
		/// <summary>
		/// Get the name of this action, i.e. "StopMonitor".
		/// </summary>
		override public string Action
		{
			get { return "StopMonitor"; }
		}
		#endregion
		#region Channel
		/// <summary>
		/// Get/Set the name of the channel to end monitoring.<br/>
		/// This property is mandatory.
		/// </summary>
		public string Channel
		{
			get { return this.channel; }
			set { this.channel = value; }
		}
		#endregion
		
		#region StopMonitorAction()
		/// <summary>
		/// Creates a new empty StopMonitorAction.
		/// </summary>
		public StopMonitorAction()
		{
		}
		#endregion
		#region StopMonitorAction(string channel)
		/// <summary>
		/// Creates a new StopMonitorAction that ends monitoring of the given channel.
		/// </summary>
		public StopMonitorAction(string channel)
		{
			this.channel = channel;
		}
		#endregion
	}
}