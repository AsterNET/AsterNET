using System;
namespace Asterisk.NET.FastAGI.Command
{
	/// <summary>
	/// Sets the priority for continuation upon exiting the application.<br/>
	/// Since Asterisk 1.2 SetPriorityCommand also supports labels.
	/// </summary>
	public class SetPriorityCommand : AGICommand
	{
		/// <summary> The priority or label for continuation upon exiting the application.</summary>
		private string priorityOrLabel;
		
		/// <summary>
		/// Get/Set the priority or label for continuation upon exiting the application.
		/// </summary>
		public int Priority
		{
			get
			{
				try
				{
					return Int32.Parse(this.priorityOrLabel);
				}
				catch {}
				return 0;
			}
			set { this.priorityOrLabel = value.ToString(); }
		}

		/// <summary>
		/// Get/Set the label for continuation upon exiting the application.
		/// </summary>
		public string Label
		{
			get { return this.priorityOrLabel; }
			set { this.priorityOrLabel = value; }
		}
		
		/// <summary>
		/// Creates a new SetPriorityCommand.
		/// </summary>
		/// <param name="priority">the priority for continuation upon exiting the application.</param>
		public SetPriorityCommand(int priority)
		{
			this.priorityOrLabel = priority.ToString();
		}

		/// <summary>
		/// Creates a new SetPriorityCommand.
		/// </summary>
		/// <param name="label">the label for continuation upon exiting the application.</param>
		public SetPriorityCommand(string label)
		{
			this.priorityOrLabel = label;
		}

		public override string BuildCommand()
		{
			return "SET PRIORITY " + EscapeAndQuote(priorityOrLabel);
		}
	}
}