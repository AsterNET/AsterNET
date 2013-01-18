namespace Asterisk.NET.Manager
{
	/// <summary>
	/// An EventTimeoutException is thrown if a ManagerResponse or some
	/// ResponseEvents are not completely received within the expected time period.<br/>
	/// This exception allows you to retrieve the partial result, that is the events
	/// that have been successfully received before the timeout occured.
	/// </summary>
	public class EventTimeoutException:TimeoutException
	{
		/// <summary>
		/// Returns the partial result that has been received before the timeout occured.<br/>
		/// Note: Using the partial result in your application should be avoided
		/// wherever possible. This is only a hack to handle those versions of
		/// Asterisk that don't follow the Manager API conventions, for example by
		/// not sending the correct ActionCompleteEvent.
		/// </summary>
		/// <returns>
		/// the ResponseEvents object filled with the parts that have been
		/// received before the timeout occured. Note: The response attribute
		/// may be <code>null</code> when no response has been received.
		/// </returns>
		public ResponseEvents PartialResult
		{
			get { return partialResult; }
		}
		private ResponseEvents partialResult;
		
		/// <summary>
		/// Creates a new EventTimeoutException with the given message and partial result.
		/// </summary>
		/// <param name="message">message with details about the timeout.</param>
		/// <param name="partialResult">the ResponseEvents object filled with the parts that
		/// have been received before the timeout occured.
		/// </param>
		public EventTimeoutException(string message, ResponseEvents partialResult): base(message)
		{
			this.partialResult = partialResult;
		}
	}
}