using System;

namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     A error ocurs when a exception is trigger
    /// </summary>
    public class ErrorEvent : ManagerEvent
    {
        public ErrorEvent(ManagerConnection source)
            : this(source, new Exception())
        {
        }

        public ErrorEvent(ManagerConnection source, Exception ex)
			: base(source)
		{
            Exception = ex;
        }

        public Exception Exception { get; set; }
    }
}