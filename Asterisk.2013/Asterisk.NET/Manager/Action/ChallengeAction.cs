using System;

namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// The ChallengeAction requests a challenge from the server to use when logging
	/// in using challenge/response. Sending this action to the asterisk server
	/// results in a ChallengeResponse being received from the server.
	/// </summary>
	/// <seealso cref="Manager.Action.LoginAction"/>
	/// <seealso cref="Manager.Response.ChallengeResponse"/>
	public class ChallengeAction : ManagerAction
	{
		private string authType;

		/// <summary>
		/// Get the name of this action, i.e. "Challenge".
		/// </summary>
		override public string Action
		{
			get { return "Challenge"; }
		}
		/// <summary>
		/// Get/Set the digest alogrithm to use. Currently asterisk only supports "MD5".
		/// </summary>
		public string AuthType
		{
			get { return this.authType; }
			set { this.authType = value; }
		}
		
		/// <summary>
		/// Creates a new empty ChallengeAction with MD5 algorithm
		/// </summary>
		public ChallengeAction()
		{
			this.authType = "MD5";
		}
		
		/// <summary>
		/// Creates a new ChallengeAction that requests a new login challenge for use
		/// with the given digest algorithm.
		/// </summary>
		/// <param name="authType">the digest alogrithm to use.</param>
		public ChallengeAction(string authType)
		{
			this.authType = authType;
		}
	}
}