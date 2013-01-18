using System;
using System.Diagnostics;
using System.Threading;
using System.Text;
using System.Collections;

namespace Asterisk.NET
{
#if LOGGER

	#region class LogFactory 
	/// <summary>
	/// Facade to hide details of the underlying logging system.
	/// </summary>
	public sealed class Logger
	{
		private static Logger logger;

		/// <summary>
		/// Returns an instance of Log suitable for logging from the given class.
		/// </summary>
		/// <returns> the created logger.</returns>
		public static Logger Instance()
		{
			if(logger == null)
				logger = new Logger();
			return logger;
		}

		public enum MessageLevel
		{
			Info,
			Warning,
			Error,
			Debug
		}

		/// <summary>
		/// Creates a new CommonsLoggingLog obtained from commons-logging's LogFactory for the given class.
		/// </summary>
		public Logger()
		{
		}

		private void writeLine(string type, string msg)
		{
			System.Diagnostics.Debug.Print(string.Format("{0}[{1}] {2}", type, Thread.CurrentThread.Name, msg));
		}
		private void writeLine(string msg)
		{
			System.Diagnostics.Debug.Print(msg);
		}

		// Max 2 calls from  original caller !
		private string debugInfo()
		{
			System.Diagnostics.StackFrame sf = new System.Diagnostics.StackFrame(2, true);
			System.Reflection.MethodBase mb = sf.GetMethod();
			return string.Concat(mb.DeclaringType.Name, ":", mb.Name);
		}


		Hashtable visibleDebug = new Hashtable();
		Hashtable visibleError = new Hashtable();
		Hashtable visibleInfo = new Hashtable();
		Hashtable visibleWarning = new Hashtable();

		private bool visibleDebugDef = true;
		private bool visibleErrorDef = true;
		private bool visibleInfoDef = true;
		private bool visibleWarningDef = true;

		/// <summary>
		/// Get visibility for message level of class:method
		/// </summary>
		/// <param name="debugClass">messageType:class:method</param>
		/// <returns></returns>
		public bool IsVisible(MessageLevel messageLevel, string classMethod)
		{
			return isVisible(messageLevel, classMethod.GetHashCode());
		}

		private bool isVisible(MessageLevel messageLevel, int hash)
		{
			switch (messageLevel)
			{
				case MessageLevel.Debug:
					return (visibleDebug.ContainsKey(hash) ? (bool)visibleDebug[hash] : visibleDebugDef);
				case MessageLevel.Error:
					return (visibleError.ContainsKey(hash) ? (bool)visibleError[hash] : visibleErrorDef);
				case MessageLevel.Info:
					return (visibleInfo.ContainsKey(hash) ? (bool)visibleInfo[hash] : visibleInfoDef);
				case MessageLevel.Warning:
					return (visibleWarning.ContainsKey(hash) ? (bool)visibleWarning[hash] : visibleWarningDef);
			}
			return true;
		}

		/// <summary>
		/// Set visibility for message level of class:method
		/// </summary>
		/// <param name="visible">visible</param>
		/// <param name="messageLevel">message level</param>
		/// <param name="classMethod">class:method</param>
		public void Visible(bool visible, MessageLevel messageLevel, string classMethod)
		{
			int hash = classMethod.GetHashCode();
			switch (messageLevel)
			{
				case MessageLevel.Debug:
					visibleDebug[hash] = visible;
					return;
				case MessageLevel.Error:
					visibleError[hash] = visible;
					return;
				case MessageLevel.Info:
					visibleInfo[hash] = visible;
					return;
				case MessageLevel.Warning:
					visibleWarning[hash] = visible;
					return;
			}
		}

		/// <summary>
		/// Set visibility for message level of class:method
		/// </summary>
		/// <param name="visible">visible</param>
		/// <param name="messageLevel">message level</param>
		/// <param name="classMethod">class:method</param>
		public void Visible(bool visible, MessageLevel messageLevel)
		{
			switch (messageLevel)
			{
				case MessageLevel.Debug:
					visibleDebugDef = visible;
					return;
				case MessageLevel.Error:
					visibleErrorDef = visible;
					return;
				case MessageLevel.Info:
					visibleInfoDef = visible;
					return;
				case MessageLevel.Warning:
					visibleWarningDef = visible;
					return;
			}
		}

		#region Debug
		public void Debug(object o)
		{
			string caller = debugInfo();
			if (isVisible(MessageLevel.Debug, caller.GetHashCode()))
				writeLine("  Debug:", string.Concat(caller, " - ", o.ToString()));
		}
		public void Debug(string msg)
		{
			string caller = debugInfo();
			if (isVisible(MessageLevel.Debug, caller.GetHashCode()))
				writeLine("  Debug:", string.Concat(caller, " - ", msg));
		}
		public void Debug(string format, params object[] args)
		{
			string caller = debugInfo();
			if (isVisible(MessageLevel.Debug, caller.GetHashCode()))
				writeLine("  Debug:", string.Concat(caller, " - ", string.Format(format, args)));
		}
		public void Debug(string msg, Exception ex)
		{
			string caller = debugInfo();
			if (isVisible(MessageLevel.Debug, caller.GetHashCode()))
				writeLine("  Debug:", string.Concat(caller, " - ", string.Format("{0}\n{1}", msg, ex)));
		}
		#endregion

		#region Info
		public void Info(object o)
		{
			string caller = debugInfo();
			if (isVisible(MessageLevel.Info, caller.GetHashCode()))
				writeLine("   Info:", string.Concat(caller, " - ", o.ToString()));
		}
		public void Info(string msg)
		{
			string caller = debugInfo();
			if (isVisible(MessageLevel.Info, caller.GetHashCode()))
				writeLine("   Info:", string.Concat(caller, " - ", msg));
		}
		public void Info(string format, params object[] args)
		{
			string caller = debugInfo();
			if (isVisible(MessageLevel.Info, caller.GetHashCode()))
				writeLine("   Info:", string.Concat(caller, " - ", string.Format(format, args)));
		}
		public void Info(string msg, Exception ex)
		{
			string caller = debugInfo();
			if (isVisible(MessageLevel.Info, caller.GetHashCode()))
				writeLine("   Info:", string.Concat(caller, " - ", string.Format("{0}\n{1}", msg, ex)));
		}
		#endregion

		#region Warning
		public void Warning(object o)
		{
			string caller = debugInfo();
			if (isVisible(MessageLevel.Warning, caller.GetHashCode()))
				writeLine("Warning:", string.Concat(caller, " - ", o.ToString()));
		}
		public void Warning(string msg)
		{
			string caller = debugInfo();
			if (isVisible(MessageLevel.Warning, caller.GetHashCode()))
				writeLine("Warning:", string.Concat(caller, " - ", msg));
		}
		public void Warning(string format, params object[] args)
		{
			string caller = debugInfo();
			if (isVisible(MessageLevel.Warning, caller.GetHashCode()))
				writeLine("Warning:", string.Concat(caller, " - ", string.Format(format, args)));
		}
		public void Warning(string msg, Exception ex)
		{
			string caller = debugInfo();
			if (isVisible(MessageLevel.Warning, caller.GetHashCode()))
				writeLine("Warning:", string.Concat(caller, " - ", string.Format("{0}\n{1}", msg, ex)));
		}
		#endregion

		#region Error
		public void Error(object o)
		{
			string caller = debugInfo();
			if (isVisible(MessageLevel.Error, caller.GetHashCode()))
				writeLine("  Error:", string.Concat(caller, " - ", o.ToString()));
		}
		public void Error(string msg)
		{
			string caller = debugInfo();
			if (isVisible(MessageLevel.Error, caller.GetHashCode()))
				writeLine("  Error:", string.Concat(caller, " - ", msg));
		}
		public void Error(string format, params object[] args)
		{
			string caller = debugInfo();
			if (isVisible(MessageLevel.Error, caller.GetHashCode()))
				writeLine("  Error:", string.Concat(caller, " - ", string.Format(format, args)));
		}
		public void Error(string msg, Exception ex)
		{
			string caller = debugInfo();
			if (isVisible(MessageLevel.Error, caller.GetHashCode()))
				writeLine("  Error:", string.Concat(caller, " - ", string.Format("{0}\n{1}", msg, ex)));
		}
		#endregion
	}
	#endregion

#endif
}