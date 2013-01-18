using System;

namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// The ExtensionStateAction queries the state of an extension in a given context.
	/// </summary>
	public class ExtensionStateAction : ManagerAction
	{
		private string exten;
		private string context;

		#region Action
		/// <summary>
		/// Get the name of this action, i.e. "ExtensionState".
		/// </summary>
		override public string Action
		{
			get { return "ExtensionState"; }
		}
		#endregion
		#region Exten
		/// <summary>
		/// Get/Set the extension to query.
		/// </summary>
		public string Exten
		{
			get { return exten; }
			set { this.exten = value; }
		}
		#endregion
		#region Context
		/// <summary>
		/// Get/Set the name of the context that contains the extension to query.
		/// </summary>
		public string Context
		{
			get { return context; }
			set { this.context = value; }
		}		
		#endregion
	}
}