using System;
namespace Asterisk.NET.Manager
{
	/// <summary>
	/// A TimeoutException is thrown if a ManagerResponse is not received within the expected time period.
	/// </summary>
	public class TimeoutException : Exception
	{
		/// <summary>
		/// Creates a new TimeoutException with the given message.
		/// </summary>
		/// <param name="message">message with details about the timeout.</param>
		public TimeoutException(string message)
			: base(message)
		{
		}
	}
}