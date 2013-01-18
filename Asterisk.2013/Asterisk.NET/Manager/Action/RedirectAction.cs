using System;

namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// Redirects a given channel (and an optional additional channel) to a new extension.
	/// </summary>
	public class RedirectAction : ManagerAction
	{
		private string channel;
		private string extraChannel;
		private string exten;
		private string context;
		private int priority;

		/// <summary>
		/// Get the name of this action, i.e. "Redirect".
		/// </summary>
		override public string Action
		{
			get { return "Redirect"; }
		}
		/// <summary>
		/// Get/Set name of the channel to redirect.
		public string Channel
		{
			get { return this.channel; }
			set { this.channel = value; }
		}
		/// <summary>
		/// Get/Set the name of the additional channel to redirect.
		/// </summary>
		public string ExtraChannel
		{
			get { return this.extraChannel; }
			set { this.extraChannel = value; }
		}
		/// <summary>
		/// Get/Set the destination context.
		/// </summary>
		public string Context
		{
			get { return this.context; }
			set { this.context = value; }
		}
		/// <summary>
		/// Get/Set the destination extension.
		/// </summary>
		public string Exten
		{
			get { return this.exten; }
			set { this.exten = value; }
		}
		/// <summary>
		/// Get/Set the destination priority.
		/// </summary>
		public int Priority
		{
			get { return this.priority; }
			set { this.priority = value; }
		}
		
		/// <summary>
		/// Creates a new empty RedirectAction.
		/// </summary>
		public RedirectAction()
		{
		}

		/// <summary>
		/// Creates a new RedirectAction that redirects the given channel to the given context, extension, priority triple.
		/// </summary>
		/// <param name="channel">the name of the channel to redirect</param>
		/// <param name="context">the destination context</param>
		/// <param name="exten">the destination extension</param>
		/// <param name="priority">the destination priority</param>
		public RedirectAction(string channel, string context, string exten, int priority)
		{
			this.channel = channel;
			this.context = context;
			this.exten = exten;
			this.priority = priority;
		}
		
		/// <summary>
		/// Creates a new RedirectAction that redirects the given channels to the given context, extension, priority triple.
		/// </summary>
		/// <param name="channel">the name of the first channel to redirect</param>
		/// <param name="extraChannel">the name of the second channel to redirect</param>
		/// <param name="context">the destination context</param>
		/// <param name="exten">the destination extension</param>
		/// <param name="priority">the destination priority</param>
		public RedirectAction(string channel, string extraChannel, string context, string exten, int priority)
		{
			this.channel = channel;
			this.extraChannel = extraChannel;
			this.context = context;
			this.exten = exten;
			this.priority = priority;
		}
	}
}