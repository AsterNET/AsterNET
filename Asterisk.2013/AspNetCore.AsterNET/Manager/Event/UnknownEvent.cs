using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.AsterNET.Manager.Event
{
	/// <summary>
	/// A UnknownEvent is triggered on unknown event from manager/proxy.
	/// </summary>
	public class UnknownEvent : ManagerEvent
	{
		/// <summary>
		/// Creates a new UnknownEvent.
		/// </summary>
		public UnknownEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}
