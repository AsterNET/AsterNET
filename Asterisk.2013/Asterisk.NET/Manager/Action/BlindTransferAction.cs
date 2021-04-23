using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     Redirect all channels currently bridged to the specified channel to the specified destination.<br />
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_BlindTransfer">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_BlindTransfer</see>
    /// </summary>
    class BlindTransferAction : ManagerAction
    {
        /// <summary>
        ///     Creates a new empty <see cref="BlindTransferAction"/>.
        /// </summary>
        public BlindTransferAction()
        {
        }

        /// <summary>
        ///     Creates a new <see cref="BlindTransferAction"/>.
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="context"></param>
        /// <param name="extension"></param>
        public BlindTransferAction(string channel, string context, string extension)
        {
            Channel = channel;
            Context = context;
            Exten = extension;
        }

        /// <summary>
        ///     Get the name of this action, i.e. "BlindTransfer".
        /// </summary>
        public override string Action
        {
            get { return "BlindTransfer"; }
        }

        /// <summary>
        ///     Gets or sets the channel.
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        ///     Gets or sets the context.
        /// </summary>
        public string Context { get; set; }

        /// <summary>
        ///     Gets or sets the extension.
        /// </summary>
        public string Exten { get; set; }
    }
}
