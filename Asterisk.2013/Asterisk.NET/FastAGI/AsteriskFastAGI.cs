using System;
using System.IO;
using System.Net;
using System.Text;
using AsterNET.FastAGI.MappingStrategies;
using AsterNET.IO;
using AsterNET.Util;

namespace AsterNET.FastAGI
{
    public class AsteriskFastAGI
    {
        #region Flags

        /// <summary>
        ///     If set to true, causes the AGIChannel to throw an exception when a status code of 511 (Channel Dead) is returned.
        ///     This is set to false by default to maintain backwards compatibility
        /// </summary>
        public bool SC511_CAUSES_EXCEPTION = false;

        /// <summary>
        ///     If set to true, causes the AGIChannel to throw an exception when return status is 0 and reply is HANGUP.
        ///     This is set to false by default to maintain backwards compatibility
        /// </summary>
        public bool SCHANGUP_CAUSES_EXCEPTION = false;

        #endregion

        #region Variables

#if LOGGER
        private readonly Logger logger = Logger.Instance();
#endif
        private ServerSocket serverSocket;

        /// <summary> The port to listen on.</summary>
        private int port;

        /// <summary> The address to listen on.</summary>
        private readonly string address;

        /// <summary>The thread pool that contains the worker threads to process incoming requests.</summary>
        private ThreadPool pool;

        /// <summary>
        ///     The number of worker threads in the thread pool. This equals the maximum number of concurrent requests this
        ///     AGIServer can serve.
        /// </summary>
        private int poolSize;

        /// <summary> True while this server is shut down. </summary>
        private bool stopped;

        /// <summary>
        ///     The strategy to use for bind AGIRequests to AGIScripts that serve them.
        /// </summary>
        private IMappingStrategy mappingStrategy;

        private Encoding socketEncoding = Encoding.ASCII;

        #endregion

        #region PoolSize

        /// <summary>
        ///     Sets the number of worker threads in the thread pool.<br />
        ///     This equals the maximum number of concurrent requests this AGIServer can serve.<br />
        ///     The default pool size is 10.
        /// </summary>
        public int PoolSize
        {
            set { poolSize = value; }
        }

        #endregion

        #region BindPort

        /// <summary>
        ///     Sets the TCP port to listen on for new connections.<br />
        ///     The default bind port is 4573.
        /// </summary>
        public int BindPort
        {
            set { port = value; }
        }

        #endregion

        #region MappingStrategy 

        /// <summary>
        ///     Sets the strategy to use for mapping AGIRequests to AGIScripts that serve them.<br />
        ///     The default mapping is a MappingStrategy.
        /// </summary>
        /// <seealso cref="MappingStrategy" />
        public IMappingStrategy MappingStrategy
        {
            set { mappingStrategy = value; }
        }

        #endregion

        #region SocketEncoding 

        public Encoding SocketEncoding
        {
            get { return socketEncoding; }
            set { socketEncoding = value; }
        }

        #endregion

        #region Constructor - AsteriskFastAGI()

        /// <summary>
        ///     Creates a new AsteriskFastAGI.
        /// </summary>
        public AsteriskFastAGI()
        {
            address = Common.AGI_BIND_ADDRESS;
            port = Common.AGI_BIND_PORT;
            poolSize = Common.AGI_POOL_SIZE;
            mappingStrategy = new ResourceMappingStrategy();
        }

        #endregion

        #region Constructor - AsteriskFastAGI()

        /// <summary>
        ///     Creates a new AsteriskFastAGI.
        /// </summary>
        public AsteriskFastAGI(string mappingStrategy)
        {
            address = Common.AGI_BIND_ADDRESS;
            port = Common.AGI_BIND_PORT;
            poolSize = Common.AGI_POOL_SIZE;
            this.mappingStrategy = new ResourceMappingStrategy(mappingStrategy);
        }

        #endregion

        #region Constructor - AsteriskFastAGI()

        /// <summary>
        ///     Creates a new AsteriskFastAGI.
        /// </summary>
        public AsteriskFastAGI(IMappingStrategy mappingStrategy)
        {
            address = Common.AGI_BIND_ADDRESS;
            port = Common.AGI_BIND_PORT;
            poolSize = Common.AGI_POOL_SIZE;
            this.mappingStrategy = mappingStrategy;
        }

        public AsteriskFastAGI(IMappingStrategy mappingStrategy, string ipaddress, int port, int poolSize)
        {
            address = ipaddress;
            this.port = port;
            this.poolSize = poolSize;
            this.mappingStrategy = mappingStrategy;
        }

        #endregion

        #region Constructor - AsteriskFastAGI(int port, int poolSize) 

        /// <summary>
        ///     Creates a new AsteriskFastAGI.
        /// </summary>
        /// <param name="port">The port to listen on.</param>
        /// <param name="poolSize">
        ///     The number of worker threads in the thread pool.
        ///     This equals the maximum number of concurrent requests this AGIServer can serve.
        /// </param>
        public AsteriskFastAGI(int port, int poolSize)
        {
            address = Common.AGI_BIND_ADDRESS;
            this.port = port;
            this.poolSize = poolSize;
            mappingStrategy = new ResourceMappingStrategy();
        }

        #endregion

        #region Constructor - AsteriskFastAGI(string address, int port, int poolSize) 

        /// <summary>
        ///     Creates a new AsteriskFastAGI.
        /// </summary>
        /// <param name="ipaddress">The address to listen on.</param>
        /// <param name="port">The port to listen on.</param>
        /// <param name="poolSize">
        ///     The number of worker threads in the thread pool.
        ///     This equals the maximum number of concurrent requests this AGIServer can serve.
        /// </param>
        public AsteriskFastAGI(string ipaddress, int port, int poolSize)
        {
            address = ipaddress;
            this.port = port;
            this.poolSize = poolSize;
            mappingStrategy = new ResourceMappingStrategy();
        }

        #endregion

        public AsteriskFastAGI(string ipaddress = Common.AGI_BIND_ADDRESS,
            int port = Common.AGI_BIND_PORT,
            int poolSize = Common.AGI_POOL_SIZE,
            bool sc511_CausesException = false,
            bool scHangUp_CausesException = false)
        {
            address = ipaddress;
            this.port = port;
            this.poolSize = poolSize;
            mappingStrategy = new ResourceMappingStrategy();
            SC511_CAUSES_EXCEPTION = sc511_CausesException;
            SCHANGUP_CAUSES_EXCEPTION = scHangUp_CausesException;
        }

        #region Start() 

        public void Start()
        {
            stopped = false;
            mappingStrategy.Load();
            pool = new ThreadPool("AGIServer", poolSize);
#if LOGGER
            logger.Info("Thread pool started.");
#endif
            try
            {
                var ipAddress = IPAddress.Parse(address);
                serverSocket = new ServerSocket(port, ipAddress, SocketEncoding);
            }
            catch (Exception ex)
            {
#if LOGGER
                if (ex is IOException)
                {
                    logger.Error("Unable start AGI Server: cannot to bind to " + address + ":" + port + ".", ex);
                }
#endif

                if (serverSocket != null)
                {
                    serverSocket.Close();
                    serverSocket = null;
                }

                pool.Shutdown();
#if LOGGER
                logger.Info("AGI Server shut down.");
#endif

                throw ex;
            }

#if LOGGER
            logger.Info("Listening on " + address + ":" + port + ".");
#endif

            try
            {
                SocketConnection socket;
                while ((socket = serverSocket.Accept()) != null)
                {
#if LOGGER
                    logger.Info("Received connection.");
#endif
                    var connectionHandler = new AGIConnectionHandler(socket, mappingStrategy, SC511_CAUSES_EXCEPTION,
                        SCHANGUP_CAUSES_EXCEPTION);
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
                logger.Info("AGI Server shut down.");
#endif
            }
        }

        #endregion

        #region Stop() 

        public void Stop()
        {
            stopped = true;
            if (serverSocket != null)
                serverSocket.Close();
        }

        #endregion
    }
}