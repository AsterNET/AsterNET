using System;

namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Raised when a caller abandons the queue.<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_QueueCallerAbandon">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_QueueCallerAbandon</see>
    /// </summary>
    public class QueueCallerAbandonEvent : ManagerEvent
	{
		private string queue;
		private int position;
		private int originalPosition;
		private int holdTime;

        /// <summary>
        /// Gets or sets the queue.
        /// </summary>
        public string Queue
		{
			get { return this.queue; }
			set { this.queue = value; }
		}
        /// <summary>
        /// Gets or sets the hold time.
        /// </summary>
        public int HoldTime
		{
			get { return this.holdTime; }
			set { this.holdTime = value; }
		}
        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        public int Position
		{
			get { return this.position; }
			set { this.position = value; }
		}
        /// <summary>
        /// Gets or sets the original position.
        /// </summary>
        public int OriginalPosition
		{
			get { return this.originalPosition; }
			set { this.originalPosition = value; }
		}
        /// <summary>
        ///     Creates a new <see cref="QueueCallerAbandonEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection" /></param>
        public QueueCallerAbandonEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}
