using System;
using System.Collections.Generic;

namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Abstract base class for bridge state related events.
    /// </summary>
    public abstract class BridgeStateEvent : ManagerEvent
	{
        /// <summary>
        ///     Gets or sets the bridge unique identifier.
        /// </summary>
        public string BridgeUniqueId { get; set; }

        /// <summary>
        ///     Gets or sets the type of the bridge.
        /// </summary>
        public string BridgeType { get; set; }

        /// <summary>
        ///     Gets or sets the bridge technology.
        /// </summary>
        public string BridgeTechnology { get; set; }

        /// <summary>
        ///     Gets or sets the bridge creator.
        /// </summary>
        public string BridgeCreator { get; set; }

        /// <summary>
        ///     Gets or sets the name of the bridge.
        /// </summary>
        public string BridgeName { get; set; }

        /// <summary>
        ///     Gets or sets the bridge number channels.
        /// </summary>
        public int BridgeNumChannels { get; set; }

        #region Constructors        
        /// <summary>
        ///     Creates a new <see cref="BridgeStateEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        /// <param name="source"></param>
        protected BridgeStateEvent(ManagerConnection source)
            : base(source)
		{
		}
		#endregion
	}
}
