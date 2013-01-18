using System;
namespace Asterisk.NET.FastAGI
{
	/// <summary>
	/// Abstract base class for all AGI specific exceptions.
	/// </summary>
	public class AGIException : Exception
	{
		public AGIException()
			: base()
		{
		}

		/// <summary>
		/// Creates a new AGIExeption with the given message.
		/// </summary>
		/// <param name="message">a message decribing the AGIException.</param>
		public AGIException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Creates a new AGIExeption with the given message and cause.
		/// </summary>
		/// <param name="message">a message decribing the AGIException.</param>
		/// <param name="cause">the throwable that caused this exception to be thrown.</param>
		public AGIException(string message, Exception cause)
			: base(message, cause)
		{
		}
	}
}