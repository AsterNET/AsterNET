using System;

namespace AsterNET.Manager.Action
{
    /// <summary>
    /// The ParkAction allows to send a Channel to a Parking lot.<br/>
    /// A successful login is the precondition for sending for that
    /// </summary>

    public class ParkAction : ManagerAction
    {
        private string channel;
        private string channel2;
        private string timeout;
        private string parkinglot;

        /// <summary>
        /// Get the name of this action, i.e. "Park".
        /// </summary>
        override public string Action
        {
            get { return "Park"; }
        }
        /// <summary>
        /// Set the Channel which should be parked
        /// </summary>
        public string Channel
        {
            get { return this.channel; }
            set { this.channel = value; }
        }
        /// <summary>
        /// Set the Channel where the Call will end up after the timeout is reached.
        /// </summary>
        public string Channel2
        {
            get { return this.channel2; }
            set { this.channel2 = value; }
        }

        /// <summary>
        /// Timeout in msec, after timeout is reached call will come back to channel2
        /// </summary>
        public string Timeout
        {
            get { return this.timeout; }
            set { this.timeout = value; }
        }
        /// <summary>
        /// Set the Parking lot.
        /// </summary>
        public string Parkinglot
        {
            get { return this.parkinglot; }
            set { this.parkinglot = value; }
        }

        /// <summary>
        /// Creates a new ParkAction.
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="channel2"></param>
        /// <param name="timeout"></param>
        public ParkAction(string channel, string channel2, string timeout)
        {
            this.channel = channel;
            this.channel2 = channel2;
            this.timeout = timeout;
        }

        /// <summary>
        /// Creates a new ParkAction.<br/>
        /// </summary>
        /// <param name="channel">Set the Channel which should be parked</param>
        /// <param name="channel2">Set the Channel where the Call will end up after the timeout is reached.</param>
        /// <param name="timeout">Timeout in msec, after timeout is reached call will come back to channel2</param>
        /// <param name="parkinglot">Set the Parking lot.</param>
        public ParkAction(string channel, string channel2, string timeout, string parkinglot)
        {
            this.channel = channel;
            this.channel2 = channel2;
            this.timeout = timeout;
            this.parkinglot = parkinglot;
        }
    }
}