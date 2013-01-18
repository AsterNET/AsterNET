using System;
namespace Asterisk.NET.Manager
{
	/// <summary>
	/// An AuthenticationFailedException is thrown when a login fails due to an incorrect username and/or password.
	/// </summary>
	public class AuthenticationFailedException : Exception
	{
		/// <summary>
		/// Creates a new AuthenticationFailedException with the given message.
		/// </summary>
		/// <param name="message">message describing the authentication failure</param>
		public AuthenticationFailedException(string message)
			: base(message)
		{
		}
		
		/// <summary>
		/// Creates a new AuthenticationFailedException with the given message and cause.
		/// </summary>
		/// <param name="message">message describing the authentication failure</param>
		/// <param name="cause">exception that caused the authentication failure</param>
		public AuthenticationFailedException(string message, Exception cause)
			: base(message, cause)
		{
		}
	}
}