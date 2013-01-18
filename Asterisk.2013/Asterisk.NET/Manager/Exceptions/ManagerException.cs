using System;
namespace Asterisk.NET.Manager
{
	/// <summary>
	/// An ManagerException is thrown when a Manager Error Response.
	/// </summary>
	public class ManagerException : Exception
	{
		/// <summary>
		/// Creates a new ManagerException with the given message.
		/// </summary>
		/// <param name="message">message describing the manager exception</param>
		public ManagerException(string message)
			: base(message)
		{
		}
		
		/// <summary>
		/// Creates a new ManagerException with the given message and cause.
		/// </summary>
		/// <param name="message">message describing the manager exception</param>
		/// <param name="cause">exception that caused the manager exception</param>
		public ManagerException(string message, Exception cause)
			: base(message, cause)
		{
		}
	}
}