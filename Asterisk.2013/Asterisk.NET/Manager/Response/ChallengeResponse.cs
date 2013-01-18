namespace Asterisk.NET.Manager.Response
{
	/// <summary>
	/// Corresponds to a ChallengeAction and contains the challenge needed to log in using challenge/response.
	/// </summary>
	/// <seealso cref="Manager.Action.ChallengeAction"/>
	/// <seealso cref="Manager.Action.LoginAction"/>
	public class ChallengeResponse : ManagerResponse
	{
		private string challenge;
		/// <summary>
		/// Get/Set the challenge to use when creating the key for log in.
		/// </summary>
		/// <seealso cref="Manager.Action.LoginAction.key"/>
		public string Challenge
		{
			get { return challenge; }
			set { this.challenge = value; }
		}
	}
}
