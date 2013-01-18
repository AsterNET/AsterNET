using System;
namespace Asterisk.NET.FastAGI
{
	/// <summary>
	/// The AGIHangupException is thrown if the channel has been hang up while processing the AGIRequest.
	/// </summary>
	public class AGIHangupException : AGIException
	{
		public AGIHangupException()
			: base("Channel was hung up.")
		{
		}
	}
}