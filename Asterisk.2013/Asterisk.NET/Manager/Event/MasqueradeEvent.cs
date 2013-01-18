using System;

namespace Asterisk.NET.Manager.Event
{
	class MasqueradeEvent : ManagerEvent
	{
		private string clone;
		private string cloneState;
		private string original;
		private string originalState;

		public string Clone
		{
			get { return this.clone; }
			set { this.clone = value; }
		}

		public string CloneState
		{
			get { return this.cloneState; }
			set { this.cloneState = value; }
		}

		public string Original
		{
			get { return this.original; }
			set { this.original = value; }
		}

		public string OriginalState
		{
			get { return this.originalState; }
			set { this.originalState = value; }
		}

		#region Constructor - MasqueradeEvent(ManagerConnection source)
		public MasqueradeEvent(ManagerConnection source)
			: base(source)
		{
		}
		#endregion
	}
}
