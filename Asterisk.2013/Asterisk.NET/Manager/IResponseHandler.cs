using System;
using System.Collections.Generic;
using System.Text;
using Asterisk.NET.Manager.Action;

namespace Asterisk.NET.Manager
{
	/// <summary>
	/// An Interface to handle responses received from an asterisk server.
	/// </summary>
	/// <seealso cref="ManagerResponse" />
	public interface IResponseHandler
	{
		/// <summary>
		/// This method is called when a response is received.
		/// </summary>
		/// <param name="response">the response received</param>
		void HandleResponse(Response.ManagerResponse response);

		void Free();

		ManagerAction Action
		{
			get;
		}

		int Hash
		{
			get;
			set;
		}
	}
}
