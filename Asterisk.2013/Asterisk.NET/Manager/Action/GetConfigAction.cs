using System;
using System.Collections.Generic;
using System.Text;
using Asterisk.NET.Manager.Response;

namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// The GetConfigAction sends a GetConfig command to the asterisk server.
	/// </summary>
	public class GetConfigAction : ManagerActionResponse
	{
		private string filename;

		/// <summary>
		/// Creates a new GetConfigAction.
		/// </summary>
		public GetConfigAction()
		{
		}

		/// <summary>
		/// Get the name of this action.
		/// </summary>
		public override string Action
		{
			get { return "GetConfig"; }
		}

		/// <summary>
		/// Get the name of this action.
		/// </summary>
		/// <param name="filename">the configuration filename.</param>
		/// </summary>
		public GetConfigAction(string filename)
		{
			this.filename = filename;
		}

		/// <summary>
		/// Get/Set the configuration filename.
		/// </summary>
		public string Filename
		{
			get { return this.filename; }
			set { this.filename = value; }
		}

		public override object ActionCompleteResponseClass()
		{
			return new GetConfigResponse();
		}
	}
}
