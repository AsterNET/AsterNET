using System;
using System.Threading;

namespace Asterisk.NET.Util
{
	/// <summary>
	/// Support class used to handle threads
	/// </summary>
	public class ThreadClass
	{
		/// <summary>The instance of Threading.Thread</summary>
		private Thread thread;

		#region ThreadClass()
		/// <summary>
		/// Initializes a new instance of the ThreadClass class
		/// </summary>
		public ThreadClass()
		{
			thread = new Thread(new ThreadStart(Run));
		}
		#endregion

		#region ThreadClass(name)
		/// <summary>
		/// Initializes a new instance of the Thread class.
		/// </summary>
		/// <param name="Name">The name of the thread</param>
		public ThreadClass(string Name)
		{
			thread = new Thread(new ThreadStart(Run));
			this.Name = Name;
		}
		#endregion

		#region ThreadClass(start)
		/// <summary>
		/// Initializes a new instance of the Thread class.
		/// </summary>
		/// <param name="start">A ThreadStart delegate that references the methods to be invoked when this thread begins executing</param>
		public ThreadClass(ThreadStart start)
		{
			thread = new Thread(start);
		}
		#endregion

		#region ThreadClass(start, name)
		/// <summary>
		/// Initializes a new instance of the Thread class.
		/// </summary>
		/// <param name="start">A ThreadStart delegate that references the methods to be invoked when this thread begins executing</param>
		/// <param name="name">The name of the thread</param>
		public ThreadClass(ThreadStart start, string name)
		{
			thread = new Thread(start);
			this.Name = name;
		}
		#endregion

		#region Run()
		/// <summary>
		/// This method has no functionality unless the method is overridden
		/// </summary>
		public virtual void Run()
		{
		}
		#endregion

		#region Start()
		/// <summary>
		/// Causes the operating system to change the state of the current thread instance to ThreadState.Running
		/// </summary>
		public void Start()
		{
			thread.Start();
		}
		#endregion

		#region Interrupt()
		/// <summary>
		/// Interrupts a thread that is in the WaitSleepJoin thread state
		/// </summary>
		public void Interrupt()
		{
			thread.Interrupt();
		}
		#endregion

		#region Name
		/// <summary>
		/// Gets or sets the name of the thread
		/// </summary>
		public string Name
		{
			get { return thread.Name; }
			set
			{
				if (thread.Name == null)
					thread.Name = value;
			}
		}
		#endregion

		#region IsAlive
		/// <summary>
		/// Gets a value indicating the execution status of the current thread
		/// </summary>
		public bool IsAlive
		{
			get { return thread.IsAlive; }
		}
		#endregion

		#region IsBackground
		/// <summary>
		/// Gets or sets a value indicating whether or not a thread is a background thread.
		/// </summary>
		public bool IsBackground
		{
			get { return thread.IsBackground; }
			set { thread.IsBackground = value; }
		}
		#endregion
	}
}
