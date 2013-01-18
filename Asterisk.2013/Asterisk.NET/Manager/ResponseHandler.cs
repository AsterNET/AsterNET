using System;
using System.Threading;
using Asterisk.NET.Manager.Action;
using Asterisk.NET.Manager.Response;

namespace Asterisk.NET.Manager
{
	/// <summary>
	/// A simple response handler that stores the received response in a ResponseHandlerResult for further processing.
	/// </summary>
	public class ResponseHandler : IResponseHandler
	{
		private ManagerResponse response;
		private AutoResetEvent autoEvent;
		private ManagerAction action;
		private int hash;

		/// <summary>
		/// Creates a new instance.
		/// </summary>
		/// <param name="result">the result to store the response in</param>
		/// <param name="thread">the thread to interrupt when the response has been received</param>
		public ResponseHandler(ManagerAction action, AutoResetEvent autoEvent)
		{
			this.response = null;
			this.action = action;
			this.autoEvent = autoEvent;
		}

		public ManagerAction Action
		{
			get { return this.action; }
		}

		public ManagerResponse Response
		{
			get { return this.response; }
		}

		public int Hash
		{
			get { return hash; }
			set { hash = value; }
		}

		public void Free()
		{
			autoEvent = null;
			action = null;
			response = null;
		}

		public virtual void HandleResponse(ManagerResponse response)
		{
			this.response = response;
			if(autoEvent != null)
				this.autoEvent.Set();
		}
	}
}
