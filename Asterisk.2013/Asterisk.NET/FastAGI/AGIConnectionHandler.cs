using System;
using System.IO;
using System.Threading;
using AsterNET.FastAGI.Command;
using AsterNET.IO;

namespace AsterNET.FastAGI
{
    /// <summary>
    ///     An AGIConnectionHandler is created and run by the AGIServer whenever a new
    ///     socket connection from an Asterisk Server is received.<br />
    ///     It reads the request using an AGIReader and runs the AGIScript configured to
    ///     handle this type of request. Finally it closes the socket connection.
    /// </summary>
    public class AGIConnectionHandler
    {
#if LOGGER
        private readonly Logger logger = Logger.Instance();
#endif
        private static readonly LocalDataStoreSlot _channel = Thread.AllocateDataSlot();
        private readonly SocketConnection socket;
        private readonly IMappingStrategy mappingStrategy;
        private readonly bool _SC511_CAUSES_EXCEPTION;
        private readonly bool _SCHANGUP_CAUSES_EXCEPTION;

        #region Channel

        /// <summary>
        ///     Returns the AGIChannel associated with the current thread.
        /// </summary>
        /// <returns>the AGIChannel associated with the current thread or  null if none is associated.</returns>
        internal static AGIChannel Channel
        {
            get { return (AGIChannel) Thread.GetData(_channel); }
        }

        #endregion

        #region AGIConnectionHandler(socket, mappingStrategy)

        /// <summary>
        ///     Creates a new AGIConnectionHandler to handle the given socket connection.
        /// </summary>
        /// <param name="socket">the socket connection to handle.</param>
        /// <param name="mappingStrategy">the strategy to use to determine which script to run.</param>
        public AGIConnectionHandler(SocketConnection socket, IMappingStrategy mappingStrategy,
            bool SC511_CAUSES_EXCEPTION, bool SCHANGUP_CAUSES_EXCEPTION)
        {
            this.socket = socket;
            this.mappingStrategy = mappingStrategy;
            _SC511_CAUSES_EXCEPTION = SC511_CAUSES_EXCEPTION;
            _SCHANGUP_CAUSES_EXCEPTION = SCHANGUP_CAUSES_EXCEPTION;
        }

        #endregion

        public void Run()
        {
            try
            {
                var reader = new AGIReader(socket);
                var writer = new AGIWriter(socket);
                AGIRequest request = reader.ReadRequest();

                //Added check for when the request is empty
                //eg. telnet to the service 
                if (request.Request.Count > 0)
                {
                    var channel = new AGIChannel(writer, reader, _SC511_CAUSES_EXCEPTION, _SCHANGUP_CAUSES_EXCEPTION);
                    AGIScript script = mappingStrategy.DetermineScript(request);
                    Thread.SetData(_channel, channel);

                    if (script != null)
                    {
                        #if LOGGER
                            logger.Info("Begin AGIScript " + script.GetType().FullName + " on " + Thread.CurrentThread.Name);
                        #endif
                        script.Service(request, channel);
                        #if LOGGER
                            logger.Info("End AGIScript " + script.GetType().FullName + " on " + Thread.CurrentThread.Name);
                        #endif
                    }
                    else
                    {
                        var error = "No script configured for URL '" + request.RequestURL + "' (script '" + request.Script +
                                    "')";
                        channel.SendCommand(new VerboseCommand(error, 1));
                        #if LOGGER
                            logger.Error(error);
                        #endif
                    }
                }
                else
                {
                    // var error = "A connection was made with no requests";
#if LOGGER
                        logger.Error(error);
#endif
                }
            }
            catch (AGIHangupException)
            {
            }
            catch (IOException)
            {
            }
            catch (AGIException ex)
            {
                #if LOGGER
                    logger.Error("AGIException while handling request", ex);
                #else
				    throw ex;
                #endif
            }
            catch (Exception ex)
            {
                #if LOGGER
                    logger.Error("Unexpected Exception while handling request", ex);
                #else
				    throw ex;
                #endif
            }

            Thread.SetData(_channel, null);
            try
            {
                socket.Close();
            }
            #if LOGGER
                catch (IOException ex)
                {
                    logger.Error("Error on close socket", ex);
                }
            #else
			    catch { }
            #endif
        }
    }
}