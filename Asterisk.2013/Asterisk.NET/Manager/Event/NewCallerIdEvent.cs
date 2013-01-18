using System;
namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A NewCallerIdEvent is triggered when the caller id of a channel changes.<br/>
	/// It is implemented in <code>channel.c</code>
	/// </summary>
	public class NewCallerIdEvent : ManagerEvent
	{
		private string callerId;
		private string callerIdNum;
		private string callerIdName;
		private string cidCallingPresTxt;
		private int cidCallingPres;

		public NewCallerIdEvent(ManagerConnection source)
			: base(source)
		{
		}

		/// <summary>
		/// Get/Set the new caller id.
		/// </summary>
		public string CallerId
		{
			get { return callerId; }
			set { this.callerId = value; }
		}
		/// <summary>
		/// Get/Set the new Caller*ID Name if set or "&lg;Unknown&gt;" if none has been set.
		/// </summary>
		public string CallerIdName
		{
			get { return callerIdName; }
			set { this.callerIdName = value; }
		}
		/// <summary>
		/// Get/Set the new Caller*ID Numb.
		/// </summary>
		public string CallerIdNum
		{
			get { return callerIdNum; }
			set { this.callerIdNum = value; }
		}
		/// <summary>
		/// Get the CallerId presentation/screening.
		/// </summary>
		public int CidCallingPresNumeric
		{
			get { return cidCallingPres; }
		}
		
		/// <summary>
		/// Get/Sets the CallerId presentation/screening in the form "%d (%s)".
		/// </summary>
		public string CidCallingPres
		{
			get
			{
				return cidCallingPres.ToString() + " (" + cidCallingPresTxt + ")";
			}
			set
			{
				string s = value;
				if (s == null || s.Length == 0)
					return;

				int spaceIdx = s.IndexOf(' ');
				if (spaceIdx <= 0)
					spaceIdx = s.Length;
				try
				{
					this.cidCallingPres = int.Parse(s.Substring(0, spaceIdx));
				}
				catch (FormatException)
				{
					return;
				}
				if (s.Length > spaceIdx + 3)
					this.cidCallingPresTxt = s.Substring(spaceIdx + 2, (s.Length - 1) - (spaceIdx + 2));
			}
		}
	}
}