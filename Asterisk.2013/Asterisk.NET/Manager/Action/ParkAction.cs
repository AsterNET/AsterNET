namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     The ParkAction allows to send a Channel to a Parking lot.<br />
    ///     A successful login is the precondition for sending for that
    /// </summary>
    public class ParkAction : ManagerAction
    {

        /// <summary>
        ///     Creates a new ParkAction.
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="channel2"></param>
        /// <param name="timeout"></param>
        public ParkAction(string channel, string channel2, string timeout)
        {
            this.Channel = channel;
            this.Channel2 = channel2;
            this.Timeout = timeout;
        }

        /// <summary>
        ///     Creates a new ParkAction.<br />
        /// </summary>
        /// <param name="channel">Set the Channel which should be parked</param>
        /// <param name="channel2">Set the Channel where the Call will end up after the timeout is reached.</param>
        /// <param name="timeout">Timeout in msec, after timeout is reached call will come back to channel2</param>
        /// <param name="parkinglot">Set the Parking lot.</param>
        public ParkAction(string channel, string channel2, string timeout, string parkinglot)
        {
            this.Channel = channel;
            this.Channel2 = channel2;
            this.Timeout = timeout;
            this.Parkinglot = parkinglot;
        }

        /// <summary>
        ///     Creates a new ParkAction with announce channel .<br />
        /// </summary>
        /// <param name="callerChannel">Set the Channel which should be parked</param>
        /// <param name="calleeChannel">Set the Channel where the Call will end up after the timeout is reached.</param>
        /// <param name="timeout">Timeout in milliseconds, after timeout is reached call will come back to channel2</param>
        /// <param name="announceChannel">If specified, then this channel will receive an announcement when Channel is parked</param>
        /// <param name="parkinglot">Set the Parking lot.</param>
        public ParkAction(string callerChannel, string calleeChannel, string announceChannel, string timeout, string parkinglot)
        {
            Channel = callerChannel;
            TimeoutChannel = calleeChannel;
            AnnounceChannel = announceChannel;
            Timeout = timeout;
            Parkinglot = parkinglot;
        }

        /// <summary>
        ///     Get the name of this action, i.e. "Park".
        /// </summary>
        public override string Action
        {
            get { return "Park"; }
        }

        /// <summary>
        ///     Set the Channel which should be parked
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        ///     Set the Channel where the Call will end up after the timeout is reached.
        /// </summary>
        public string Channel2 { get; set; }

        /// <summary>
        ///     Set the Channel where the Call will end up after the timeout is reached.
        /// </summary>
        public string TimeoutChannel { get; set; }

        /// <summary>
        ///     Set the Announcement Channel to receive the AMI Announcement.
        /// </summary>
        public string AnnounceChannel { get; set; }

        /// <summary>
        ///     Timeout in msec, after timeout is reached call will come back to channel2
        /// </summary>
        public string Timeout { get; set; }

        /// <summary>
        ///     Set the Parking lot.
        /// </summary>
        public string Parkinglot { get; set; }
    }
}
