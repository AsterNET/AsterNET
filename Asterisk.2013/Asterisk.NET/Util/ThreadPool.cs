using System.Threading;
using System.Collections;
using Asterisk.NET.FastAGI;
using System.Collections.Generic;

namespace Asterisk.NET.Util
{
	/// <summary>
	/// A fixed sized thread pool.
	/// </summary>
	public class ThreadPool
	{
#if LOGGER
		private Logger logger = Logger.Instance();
#endif
		private bool running;
		private int numThreads;
		private string name;
		private List<AGIConnectionHandler> jobs;

		#region Constructor - ThreadPool(string name, int numThreads) 
		/// <summary>
		/// Creates a new ThreadPool of numThreads size. These Threads are waiting
		/// for jobs to be added via the addJob method.
		/// </summary>
		/// <param name="name">the name to use for the thread group and worker threads.</param>
		/// <param name="numThreads">the number of threads to create.</param>
		public ThreadPool(string name, int numThreads)
		{
			this.name = name;
			this.numThreads = numThreads;
			jobs = new List<AGIConnectionHandler>();
			running = true;

			// create and start the threads
			for (int i = 0; i < this.numThreads; i++)
			{
				ThreadTask thread;
				thread = new ThreadTask(this, this.name + "-TaskThread-" + i);
				thread.Start();
			}
#if LOGGER
			logger.Debug("ThreadPool created with " + this.numThreads + " threads.");
#endif
		}
		#endregion

		#region obtainJob() 
		/// <summary>
		/// Gets a job from the queue. If none is availble the calling thread is
		/// blocked until one is added.
		/// </summary>
		/// <returns>the next job to service, <code>null</code> if the worker thread should be shut down.</returns>
		internal AGIConnectionHandler obtainJob()
		{
			AGIConnectionHandler job = null;
			lock (jobs)
			{
				while (job == null && running)
				{
					try
					{
						if (jobs.Count == 0)
							Monitor.Wait(jobs);
					}
					catch (ThreadInterruptedException ex)
					{
#if LOGGER
						logger.Error("System.Threading.ThreadInterruptedException.", ex);
#else
						throw ex;
#endif
					}
					if (jobs.Count > 0)
					{
						job = jobs[0];
						jobs.RemoveAt(0);
					}
				}
			}

			if (running)
				return job;
			else
				return null;
		}
		#endregion

		#region AddJob(AGIConnectionHandler runnable)
		/// <summary> Adds a new job to the queue. This will be picked up by the next available
		/// active thread.
		/// </summary>
		public void AddJob(AGIConnectionHandler runnable)
		{
			lock (jobs)
			{
				jobs.Add(runnable);
				Monitor.PulseAll(jobs);
			}
		}
		#endregion

		#region Shutdown() 
		/// <summary> Turn off the pool. Every thread, when finished with its current work,
		/// will realize that the pool is no longer running, and will exit.
		/// </summary>
		public void Shutdown()
		{
			running = false;
			lock (jobs)
				Monitor.PulseAll(jobs);
#if LOGGER
			logger.Debug("ThreadPool shutting down.");
#endif
		}
		#endregion
	}
}