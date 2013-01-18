using System;
namespace Asterisk.NET.FastAGI.Command
{
	/// <summary>
	/// Sets the extension for continuation upon exiting the application.
	/// </summary>
	public class SetExtensionCommand : AGICommand
	{
		/// <summary>
		/// Get/Set the extension for continuation upon exiting the application.
		/// </summary>
		/// <returns>the extension for continuation upon exiting the application.</returns>
		/// <param name="extension">the extension for continuation upon exiting the application.</param>
		public string Extension
		{
			get { return extension; }
			set { this.extension = value; }
		}
		
		/// <summary> The extension for continuation upon exiting the application.</summary>
		private string extension;
		
		/// <summary>
		/// Creates a new SetPriorityCommand.
		/// </summary>
		/// <param name="extension">the extension for continuation upon exiting the application.</param>
		public SetExtensionCommand(string extension)
		{
			this.extension = extension;
		}
		
		public override string BuildCommand()
		{
			return "SET EXTENSION " + EscapeAndQuote(extension);
		}
	}
}