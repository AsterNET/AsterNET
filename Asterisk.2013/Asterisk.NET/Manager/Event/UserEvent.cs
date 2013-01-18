using System;
using System.Collections;
using System.Collections.Generic;

namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// Abstract base class for user events.<br/>
	/// You can send arbitrary user events via the UserEvent application provided with asterisk.
	/// A user event by default has the attributes channel and uniqueId but you can add custom
	/// attributes by specifying an event body.<br/>
	/// To add your own user events you must subclass this class and name it corresponding to your event.<br/>
	/// If you plan to send an event by <code>UserEvent(VIPCall)</code> you will create a new class
	/// called VIPCallEvent that extends UserEvent. The name of this class is important: Just use the
	/// name of the event you will send (VIPCall in this example) and append "Event".<br/> 
	/// To pass additional data create appropriate attributes with getter and setter methods in your new class.<br/>
	/// Example:
	/// <pre>
	 /// public class VIPCallEvent : UserEvent
	 /// {
	/// 	 private string firstName;
	/// 	 // Constructor
	/// 	 public VIPCallEvent()
	/// 	 {
	/// 	 }
	/// 	 // Property
	/// 	 public string FirstName
	/// 	 {
	/// 		 get { return this.firstName; }
	/// 		 set { this.firstName = value; }
	/// 	 }
	 ///  }
	 /// </pre>
	/// To send this event use <code>UserEvent(VIPCall|firstName: Jon)</code> in your dialplan.<br/>
	/// The UserEvent is implemented in <code>apps/app_userevent.c</code>.<br/>
	/// Note that you must register your UserEvent with the ManagerConnection you are using in order to be recognized.
	/// </summary>
	/// <seealso cref="Manager.ManagerConnection.RegisterUserEventClass(Type userEventClass)"/>
	public class UserEvent : ManagerEvent
	{
		private string userEventName;

		public override bool Parse(string key, string value)
		{
			if (key == "userevent")
				userEventName = value;
			return base.Parse(key, value);
		}

		public string UserEventName
		{
			get { return userEventName; }
			set { userEventName = value; }
		}

		public UserEvent(ManagerConnection source)
			: base(source)
		{ }
	}
}