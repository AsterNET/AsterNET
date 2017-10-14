namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     A error ocurs when a exception is trigger
    /// </summary>
    public class ErrorEvent : ManagerEvent
    {
        public ErrorEvent(ManagerConnection source)
            : this(source, string.Empty)
        {
        }

        public ErrorEvent(ManagerConnection source, string reason)
			: base(source)
		{
            Exception = reason;
        }

        public string Exception { get; set; }
    }
}