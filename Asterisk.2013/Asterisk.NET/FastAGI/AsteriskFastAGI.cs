using System.IO;
using System.Net;
using System.Text;

namespace Asterisk.NET.FastAGI
{
	public class AsteriskFastAGI
	{
		#region Variables
#if LOGGER
		private Logger logger = Logger.Instance();
#endif
		private IO.ServerSocket serverSocket;

		/// <summary> The port to listen on.</summary>
		private int port;
		/// <summary> The address to listen on.</summary>
		private string address;
		/// <summary>The thread pool that contains the worker threads to process incoming requests.</summary>
		private Util.ThreadPool pool;
		/// <summary>The number of worker threads in the thread pool. This equals the maximum number of concurrent requests this AGIServer can serve.</summary>
		private int poolSize;
		/// <summary> True while this server is shut down. </summary>
		private bool stopped;
		/// <summary>
		/// The strategy to use for bind AGIRequests to AGIScripts that serve them.
		/// </summary>
		private MappingStrategy mappingStrategy;
		private Encoding socketEncoding = Encoding.ASCII;
		#endregion

		#region PoolSize
		/// <summary>
		/// Sets the number of worker threads in the thread pool.<br/>
		/// This equals the maximum number of concurrent requests this AGIServer can serve.<br/>
		/// The default pool size is 10.
		/// </summary>
		public int PoolSize
		{
			set { this.poolSize = value; }
		}
		#endregion

		#region BindPort
		/// <summary>
		/// Sets the TCP port to listen on for new connections.<br/>
		/// The default bind port is 4573.
		/// </summary>
		public int BindPort
		{
			set
			{
				this.port = value;
			}
		}
		#endregion

		#region MappingStrategy 
		/// <summary>
		/// Sets the strategy to use for mapping AGIRequests to AGIScripts that serve them.<br/>
		/// The default mapping is a MappingStrategy.
		/// </summary>
		/// <seealso cref="MappingStrategy" />
		public MappingStrategy MappingStrategy
		{
			set { this.mappingStrategy = value; }
		}
		#endregion

		#region SocketEncoding 
		public Encoding SocketEncoding
		{
			get { return this.socketEncoding; }
			set { this.socketEncoding = value; }
		}
		#endregion

		#region Constructor - AsteriskFastAGI()
		/// <summary>
		/// Creates a new AsteriskFastAGI.
		/// </summary>
		public AsteriskFastAGI()
		{
			this.address = Common.AGI_BIND_ADDRESS;
			this.port = Common.AGI_BIND_PORT;
			this.poolSize = Common.AGI_POOL_SIZE;
			this.mappingStrategy = new MappingStrategy();
		}
		#endregion

		#region Constructor - AsteriskFastAGI()
		/// <summary>
		/// Creates a new AsteriskFastAGI.
		/// </summary>
		public AsteriskFastAGI(string mappingStrategy)
		{
			this.address = Common.AGI_BIND_ADDRESS;
			this.port = Common.AGI_BIND_PORT;
			this.poolSize = Common.AGI_POOL_SIZE;
			this.mappingStrategy = new MappingStrategy(mappingStrategy);
		}
		#endregion

		#region Constructor - AsteriskFastAGI(int port, int poolSize) 
		/// <summary>
		/// Creates a new AsteriskFastAGI.
		/// </summary>
		/// <param name="port">The port to listen on.</param>
		/// <param name="poolSize">The number of worker threads in the thread pool.
		/// This equals the maximum number of concurrent requests this AGIServer can serve.</param>
		public AsteriskFastAGI(int port, int poolSize)
		{
			this.address = Common.AGI_BIND_ADDRESS;
			this.port = port;
			this.poolSize = poolSize;
			this.mappingStrategy = new MappingStrategy();
		}
		#endregion

		#region Constructor - AsteriskFastAGI(string address, int port, int poolSize) 
		/// <summary>
		/// Creates a new AsteriskFastAGI.
		/// </summary>
		/// <param name="ipaddress">The address to listen on.</param>
		/// <param name="port">The port to listen on.</param>
		/// <param name="poolSize">The number of worker threads in the thread pool.
		/// This equals the maximum number of concurrent requests this AGIServer can serve.</param>
		public AsteriskFastAGI(string ipaddress, int port, int poolSize)
		{
			this.address = ipaddress;
			this.port = port;
			this.poolSize = poolSize;
			this.mappingStrategy = new MappingStrategy();
		}
		#endregion

		#region Start() 
		public void Start()
		{
			stopped = false;
			mappingStrategy.Load();
			pool = new Util.ThreadPool("AGIServer", poolSize);
#if LOGGER
			logger.Info("Thread pool started.");
#endif
			try
			{
				IPAddress ipAddress = IPAddress.Parse(address);
				serverSocket = new IO.ServerSocket(port, ipAddress, this.SocketEncoding);
			}
			catch(IOException ex)
			{
#if LOGGER
				logger.Error("Unable start AGI Server: cannot to bind to "+ address + ":" + port + ".", ex);
#endif
				throw ex;
			}
#if LOGGER
			logger.Info("Listening on "+ address + ":" + port + ".");
#endif

			AGIConnectionHandler connectionHandler;
			IO.SocketConnection socket;
			try
			{
				while ((socket = serverSocket.Accept()) != null)
				{
#if LOGGER
					logger.Info("Received connection.");
#endif
					connectionHandler = new AGIConnectionHandler(socket, mappingStrategy);
					pool.AddJob(connectionHandler);
				}
			}
			catch (IOException ex)
			{
				if (!stopped)
				{
#if LOGGER
					logger.Error("IOException while waiting for connections (1).", ex);
#endif
					throw ex;
				}
			}
			finally
			{
				if (serverSocket != null)
				{
					try
					{
						serverSocket.Close();
					}
#if LOGGER
					catch (IOException ex)
					{
						logger.Error("IOException while waiting for connections (2).", ex);
					}
#else
					catch { }
#endif
				}
				serverSocket = null;
				pool.Shutdown();
#if LOGGER
				logger.Info("AGIServer shut down.");
#endif
			}
		}
		#endregion

		#region Stop() 
		public void  Stop()
		{
			stopped = true;
			if (serverSocket != null)
				serverSocket.Close();
		}
		#endregion
	}
}
