using System;
namespace Asterisk.NET.FastAGI.Command
{
	/// <summary>
	/// Sets the context for continuation upon exiting the application.
	/// </summary>
	public class SetContextCommand : AGICommand
	{
		/// <summary> The context for continuation upon exiting the application.</summary>
		private string context;

		/// <summary>
		/// Get/Set the context for continuation upon exiting the application.
		/// </summary>
		public string Context
		{
			get { return context; }
			set { this.context = value; }
		}
		
		/// <summary>
		/// Creates a new SetPriorityCommand.
		/// </summary>
		/// <param name="context">the context for continuation upon exiting the application.</param>
		public SetContextCommand(string context)
		{
			this.context = context;
		}
		
		public override string BuildCommand()
		{
			return "SET CONTEXT " + EscapeAndQuote(context);
		}
	}
}