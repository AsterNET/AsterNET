using System;

namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// The LogoffAction causes the server to close the connection.
	/// </summary>
	public class LogoffAction : ManagerAction
	{
		/// <summary>
		/// Get the name of this action, i.e. "Logoff".
		/// </summary>
		override public string Action
		{
			get { return "Logoff"; }
		}
		
		/// <summary>
		/// Creates a new LogoffAction.
		/// </summary>
		public LogoffAction()
		{
		}
	}
}