using AsterNET.Manager.Event;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace AsterNET.Manager.Action
{
	public class CoreShowChannelsAction : ManagerActionEvent
	{
		#region Action

		/// <summary>
		///     Get the name of this action, i.e. "CoreShowChannels".
		/// </summary>
		public override string Action
		{
			get { return "CoreShowChannels"; }
		}

		#endregion

		public override Type ActionCompleteEventClass()
		{
			return typeof(CoreShowChannelsCompleteEvent);
		}
	}
}