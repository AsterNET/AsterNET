using System;

namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// The LoginAction authenticates the connection.<br/>
	/// A successful login is the precondition for sending any other action except
	/// for the ChallengeAction.<br/>
	/// An unsuccessful login results in an ManagerError being received from the
	/// server with a message set to "Authentication failed" and the socket being
	/// closed by Asterisk.
	/// </summary>
	/// <seealso cref="Manager.Action.ChallengeAction" />
	/// <seealso cref="Manager.Response.ManagerError" />
	public class LoginAction : ManagerAction
	{
		private string username;
		private string secret;
		private string authType;
		private string key;
		private string events;

		/// <summary>
		/// Get the name of this action, i.e. "Login".
		/// </summary>
		override public string Action
		{
			get { return "Login"; }
		}
		/// <summary>
		/// Get/Set the username as configured in asterik's <code>manager.conf</code>.</summary>
		public string Username
		{
			get { return this.username; }
			set { this.username = value; }
		}
		/// <summary>
		/// Get/Set the secret to use when using cleartext login.<br/>
		/// The secret contains the user's password as configured in Asterisk's <code>manager.conf</code>.<br/>
		/// The secret and key properties are mutually exclusive.
		/// </summary>
		public string Secret
		{
			get { return this.secret; }
			set { this.secret = value; }
		}
		/// <summary>
		/// Get/Set the digest alogrithm when using challenge/response.<br/>
		/// The digest algorithm is used to create the key based on the challenge and
		/// the user's password.<br/>
		/// Currently Asterisk supports only "MD5".
		/// </summary>
		public string AuthType
		{
			get { return this.authType; }
			set { this.authType = value; }
		}
		/// <summary>
		/// Get/Set the key.
		/// </summary>
		public string Key
		{
			get { return this.key; }
			set { this.key = value; }
		}
		/// <summary>
		/// Get/Set the event mask.<br/>
		/// Set to "on" if all events should be send, "off" if not events should be sent or a combination of
		/// "system", "call" and "log" (separated by ',') to specify what kind of events should be sent.
		/// </summary>
		public string Events
		{
			get { return this.events; }
			set { this.events = value; }
		}
		
		/// <summary>
		/// Creates a new empty LoginAction.
		/// </summary>
		public LoginAction()
		{
		}
		
		/// <summary>
		/// Creates a new LoginAction that performs a cleartext login.<br/>
		/// You should not use cleartext login if you are concerned about security and login with a password hash instead.
		/// </summary>
		/// <param name="username">the username as configured in Asterisk's <code>manager.conf</code></param>
		/// <param name="secret">the user's password as configured in Asterisk's <code>manager.conf</code></param>
		/// <seealso cref="Manager.Action.ChallengeAction" />
		public LoginAction(string username, string secret)
		{
			this.username = username;
			this.secret = secret;
		}
		
		/// <summary>
		/// Creates a new LoginAction that performs a login via challenge/response.
		/// </summary>
		/// <param name="username">the username as configured in Asterisk's <code>manager.conf</code></param>
		/// <param name="authType">the digest alogrithm, must match the digest algorithm that was used with the corresponding ChallengeAction.</param>
		/// <param name="key">the hash of the user's password and the challenge</param>
		public LoginAction(string username, string authType, string key)
		{
			this.username = username;
			this.authType = authType;
			this.key = key;
		}
		
		/// <summary>
		/// Creates a new LoginAction that performs a login via challenge/response.
		/// </summary>
		/// <param name="username">the username as configured in Asterisk's <code>manager.conf</code></param>
		/// <param name="authType">the digest alogrithm, must match the digest algorithm that was used with the corresponding ChallengeAction.</param>
		/// <param name="key">the hash of the user's password and the challenge</param>
		/// <param name="events">the event mask.<br/>
		/// Set to "on" if all events should be send, "off" if not events should be sent
		/// or a combination of "system", "call" and "log" (separated by ',') to specify what kind of events should be sent.
		/// </param>
		public LoginAction(string username, string authType, string key, string events)
		{
			this.username = username;
			this.authType = authType;
			this.key = key;
			this.events = events;
		}
	}
}