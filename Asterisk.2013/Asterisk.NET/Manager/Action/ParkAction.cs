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
            this.TimeoutChannel = channel2;
            this.Timeout = timeout;
        }

        /// <summary>
        ///     Creates a new ParkAction with Announcement.<br />
        /// </summary>
        /// <param name="channel">Set the Channel which should be parked</param>
        /// <param name="TimeoutChannel">Channel name to use when constructing the dial string that will be dialed if the parked channel times out. If TimeoutChannel is in a two party bridge with Channel, then TimeoutChannel will receive an announcement and be treated as having parked Channel in the same manner as the Park Call DTMF feature.</param>
        /// <param name="AnnounceChannel"> If specified, then this channel will receive an announcement when Channel is parked if AnnounceChannel is in a state where it can receive announcements (AnnounceChannel must be bridged). AnnounceChannel has no bearing on the actual state of the parked call.</param>
        /// <param name="timeout">Timeout in msec, after timeout is reached call will come back to channel2</param>
        public ParkAction(string channel, string TimeoutChannel, string AnnounceChannel, string timeout)
        {
            this.Channel = channel;
            this.TimeoutChannel = TimeoutChannel;
            this.AnnounceChannel = AnnounceChannel;
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
            this.TimeoutChannel = channel2;
            this.Timeout = timeout;
            this.Parkinglot = parkinglot;
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
        ///     Channel name to use when constructing the dial string that will be dialed if the parked channel times out. If TimeoutChannel is in a two party bridge with Channel, then TimeoutChannel will receive an announcement and be treated as having parked Channel in the same manner as the Park Call DTMF feature.
        /// </summary>
        public string TimeoutChannel { get; set; }
        
        /// <summary>
        ///    AnnounceChannel is in a state where it can receive announcements 
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
