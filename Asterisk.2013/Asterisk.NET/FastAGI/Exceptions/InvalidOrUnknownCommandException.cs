using System;
namespace Asterisk.NET.FastAGI
{
	/// <summary>
	/// An InvalidOrUnknownCommandException is thrown when the reader receives a reply with status code 510.
	/// </summary>
	public class InvalidOrUnknownCommandException : AGIException
	{
		
		/// <summary>
		/// Creates a new InvalidOrUnknownCommandException.
		/// </summary>
		/// <param name="command">the invalid or unknown command.</param>
		public InvalidOrUnknownCommandException(string command)
			: base("Invalid or unknown command: " + command)
		{
		}
	}
}