using System;
namespace Asterisk.NET.FastAGI
{
	/// <summary>
	/// The AGINetworkException usally wraps an IOException denoting a network problem when talking to the Asterisk server.
	/// </summary>
	public class AGINetworkException : AGIException
	{
		public AGINetworkException(string message, Exception cause)
			: base(message, cause)
		{
		}
	}
}