namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A StatusEvent is triggered for each active channel in response to a StatusAction.
	/// </summary>
	/// <seealso cref="Manager.Action.StatusAction" />
	public class StatusEvent : ResponseEvent
	{
		/// <summary> Returns the Caller*ID of this channel.</summary>
		/// <summary> Sets the Caller*ID of this channel.</summary>
		public string CallerId
		{
			get
			{
				return callerId;
			}
			
			set
			{
				this.callerId = value;
			}
			
		}
		/// <summary> Returns the Caller*ID Name of this channel.</summary>
		/// <summary> Sets the Caller*ID Name of this channel.</summary>
		public string CallerIdName
		{
			get
			{
				return callerIdName;
			}
			
			set
			{
				this.callerIdName = value;
			}
			
		}
		/// <summary> Returns the Caller*ID Number of this channel.</summary>
		/// <summary> Sets the Caller*ID Number of this channel.</summary>
		public string CallerIdNum
		{
			get
			{
				return callerIdNum;
			}

			set
			{
				this.callerIdNum = value;
			}

		}
		/// <summary> Returns the account code of this channel.</summary>
		/// <summary> Sets the account code of this channel.</summary>
		public string Account
		{
			get
			{
				return account;
			}
			
			set
			{
				this.account = value;
			}
			
		}
		public string State
		{
			get
			{
				return state;
			}
			
			set
			{
				this.state = value;
			}
			
		}
		public string Context
		{
			get
			{
				return context;
			}
			
			set
			{
				this.context = value;
			}
			
		}
		public string Extension
		{
			get
			{
				return extension;
			}
			
			set
			{
				this.extension = value;
			}
			
		}
		public int Priority
		{
			get
			{
				return priority;
			}
			
			set
			{
				this.priority = value;
			}
			
		}
		/// <summary> Returns the number of elapsed seconds.</summary>
		/// <summary> Sets the number of elapsed seconds.</summary>
		public int Seconds
		{
			get
			{
				return seconds;
			}
			
			set
			{
				this.seconds = value;
			}
			
		}
		/// <summary> Returns the name of the linked channel if this channel is bridged.</summary>
		/// <summary> Sets the name of the linked channel.</summary>
		public string Link
		{
			get
			{
				return link;
			}
			
			set
			{
				this.link = value;
			}
			
		}
		private string callerId;
		private string callerIdName;
		private string callerIdNum;
		private string account;
		private string state;
		private string context;
		private string extension;
		private int priority;
		private int seconds = -1;
		private string link;
		
		public StatusEvent(ManagerConnection source): base(source)
		{
		}
	}
}