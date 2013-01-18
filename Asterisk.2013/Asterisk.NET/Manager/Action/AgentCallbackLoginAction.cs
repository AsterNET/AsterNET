using System;

namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// The AgentCallbackLoginAction sets an agent as logged in with callback.<br/>
	/// You can pass an extentsion (and optionally a context) to specify the
	/// destination of the callback.<br/>
	/// In contrast to the AgentCallbackLogin application that you can use within
	/// Asterisk's dialplan, you don't need to know the agent's password when logging
	/// in an agent.<br/>
	/// Available since Asterisk 1.2
	/// </summary>
	public class AgentCallbackLoginAction : ManagerAction
	{
		private string agent;
		private string exten;
		private string context;
		private bool ackCall;
		private long wrapupTime;

		/// <summary>
		/// Get the name of this action, i.e. "AgentCallbackLogin".
		/// </summary>
		override public string Action
		{
			get { return "AgentCallbackLogin"; }
		}
		/// <summary>
		/// Get/Set the name of the agent to log in, for example "1002".<br/>
		/// This is property is mandatory.
		/// </summary>
		public string Agent
		{
			get { return this.agent; }
			set { this.agent = value; }
		}
		/// <summary>
		/// Get/Set the extension to use for callback.<br/>
		/// This is property is mandatory.
		/// </summary>
		public string Exten
		{
			get { return this.exten; }
			set { this.exten = value; }
		}
		/// <summary>
		/// Get/Set the context of the extension to use for callback.
		/// </summary>
		public string Context
		{
			get { return this.context; }
			set { this.context = value; }
		}
		/// <summary>
		/// Get/Set if an acknowledgement is needed when agent is called back.<br/>
		/// <code>true</code> if acknowledgement by '#' is required when agent is called back, <code>false</code> otherwise.
		/// This property is optional, it allows you to override the defaults defined in Asterisk's configuration.
		/// </summary>
		public bool AckCall
		{
			get { return this.ackCall; }
			set { this.ackCall = value; }
		}
		/// <summary>
		/// Returns the minimum amount of time (in milliseconds) after disconnecting before the caller can receive a new call.<br/>
		/// This property is optional, it allows you to override the defaults defined in Asterisk's configuration.
		/// </summary>
		public long WrapupTime
		{
			get { return this.wrapupTime; }
			set { this.wrapupTime = value; }
		}

		/// <summary>
		/// Creates a new empty AgentCallbackLoginAction.
		/// </summary>
		public AgentCallbackLoginAction()
		{
		}
		
		/// <summary>
		/// Creates a new AgentCallbackLoginAction, that logs in the given agent at
		/// the given callback extension.
		/// </summary>
		/// <param name="agent">the name of the agent to log in</param>
		/// <param name="exten">the extension that is called to connect a queue member with this agent</param>
		public AgentCallbackLoginAction(string agent, string exten)
		{
			this.agent = agent;
			this.exten = exten;
		}
		
		/// <summary>
		/// Creates a new AgentCallbackLoginAction, that logs in the given agent at
		/// the given callback extension in the given context.
		/// </summary>
		/// <param name="agent">the name of the agent to log in</param>
		/// <param name="exten">the extension that is called to connect a queue member with this agent</param>
		/// <param name="context">the context of the extension to use for callback</param>
		public AgentCallbackLoginAction(string agent, string exten, string context)
			: this(agent, exten)
		{
			this.context = context;
		}
	}
}