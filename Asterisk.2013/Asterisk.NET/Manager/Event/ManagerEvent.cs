using System;
using System.Collections.Generic;

namespace AsterNET.Manager.Event
{
    /// <summary>
    /// Abstract base class for all Events that can be received from the Asterisk server.<br/>
    /// Events contain data pertaining to an event generated from within the Asterisk
    /// core or an extension module.<br/>
    /// There is one conrete subclass of ManagerEvent per each supported Asterisk Event.
    /// 
    /// Channel / Privilege / UniqueId are not common to all events and should be moved to
    /// derived event classes.
    /// </summary>
    public abstract class ManagerEvent : EventArgs, IParseSupport
    {
        #region Common Event Properties

        /// <summary>
        /// Store all unknown (without setter) keys from manager event.<br/>
        /// Use in default Parse method <see cref="ManagerEvent.Parse(string, string)"/>
        /// </summary>
        public Dictionary<string, string> Attributes { get; } = new Dictionary<string, string>();

        /// <summary>
        /// Get/Set the name of the channel.
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        /// Get/Set the point in time this event was received from the Asterisk server.<br/>
        /// Pseudo events that are not directly received from the asterisk server
        /// (for example ConnectEvent and DisconnectEvent) may return null.
        /// </summary>
        public DateTime DateReceived { get; set; }

        /// <summary>
        /// Get/Set the AMI authorization class of this event.<br/>
        /// This is one or more of system, call, log, verbose, command, agent or user.
        /// Multiple privileges are separated by comma.<br/>
        /// Note: This property is not available from Asterisk 1.0 servers.
        /// </summary>
        public string Privilege { get; set; }

        /// <summary>
        /// Specify a server to which to send your commands (x.x.x.x or hostname).<br/>
        /// This should match the server name specified in your config file's "host" entry.
        /// If you do not specify a server, the proxy will pick the first one it finds -- fine in single-server configurations.
        /// </summary>
        public string Server { get; set; }

        /// <summary>
        /// The ManagerConnection the Event was sourced from.
        /// </summary>
        public ManagerConnection Source { get; set; }

        /// <summary>
        /// Returns the timestamp for this event.<br/>
        /// The timestamp property is available in Asterisk since 1.4
        /// if enabled in manager.conf by setting timestampevents = yes.
        /// In contains the time the event was generated in seconds since the epoch.
        /// </summary>
        public double Timestamp { get; set; }

        /// <summary>
        /// Get/Set the unique id of the channel.
        /// </summary>
        public string UniqueId { get; set; }

        #endregion

        #region Constructors 
        /// <summary>
        /// Creates a new ManagerEvent. Source already set.
        /// </summary>
        public ManagerEvent()
        {
            this.DateReceived = DateTime.Now;
        }

        /// <summary>
        /// Creates a new ManagerEvent
        /// </summary>
        /// <param name="source">ManagerConnection passed through in the event.</param>
		public ManagerEvent(ManagerConnection source)
            : this()
        {
            this.Source = source;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Unknown properties parser
        /// </summary>
        /// <param name="key">key name</param>
        /// <param name="value">key value</param>
        /// <returns>true - value parsed, false - can't parse value</returns>
        public virtual bool Parse(string key, string value)
        {
            if (Attributes.ContainsKey(key))
            {
                Attributes[key] += string.Concat(Common.LINE_SEPARATOR, value); // Key already presents, add with delimiter
            }
            else
            {
                Attributes.Add(key, value);
            }

            return true;
        }

        /// <summary>
        /// Unknown properties parser.
        /// </summary>
        /// <param name="attributes">dictionary</param>
        /// <returns>updated dictionary</returns>
        public virtual Dictionary<string, string> ParseSpecial(Dictionary<string, string> attributes)
        {
            return attributes;
        }

        /// <summary>
        ///  Convert all properties to string
        /// </summary>
        /// <returns>All event details and properties as a string</returns>
		public override string ToString()
        {
            return Helper.ToString(this);
        }
        #endregion
    }
}
