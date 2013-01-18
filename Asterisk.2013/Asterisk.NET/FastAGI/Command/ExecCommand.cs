using System;
namespace Asterisk.NET.FastAGI.Command
{
	/// <summary>
	/// Executes an application with the given options.<br/>
	/// Returns whatever the application returns, or -2 if the application was not found.
	/// </summary>
	public class ExecCommand : AGICommand
	{
		/// <summary> The name of the application to execute.</summary>
		private string application;
		/// <summary> The options to pass to the application.</summary>
		private string options;

		/// <summary>
		/// Get/Set the name of the application to execute.
		/// </summary>
		public string Application
		{
			get { return application; }
			set { this.application = value; }
		}
		/// <summary>
		/// Get/Set the options to pass to the application.
		/// </summary>
		public string Options
		{
			get { return options; }
			set { this.options = value; }
		}
		
		/// <summary>
		/// Creates a new ExecCommand.
		/// </summary>
		/// <param name="application">the name of the application to execute.</param>
		public ExecCommand(string application)
		{
			this.application = application;
		}
		
		/// <summary>
		/// Creates a new ExecCommand.
		/// </summary>
		/// <param name="application">the name of the application to execute.</param>
		/// <param name="options">the options to pass to the application.</param>
		public ExecCommand(string application, string options)
		{
			this.application = application;
			this.options = options;
		}
		
		public override string BuildCommand()
		{
			return "EXEC " + EscapeAndQuote(application) + " " + EscapeAndQuote(options);
		}
	}
}