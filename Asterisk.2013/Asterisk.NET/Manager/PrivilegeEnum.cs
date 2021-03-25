using System;
using System.Collections.Generic;
using System.Text;

namespace AsterNET.Manager
{
    [Flags]
    public enum PrivilegeEnum
    {
        /// <summary>
        /// General information about the system and ability to run system management commands, such as Shutdown, Restart, and Reload
        /// </summary>
        system,

        /// <summary>
        /// Information about channels and ability to set information in a running channel
        /// </summary>
        call,

        /// <summary>
        /// Logging information. Read-only
        /// </summary>
        log,

        /// <summary>
        /// Verbose information. Read-only
        /// </summary>
        verbose,

        /// <summary>
        /// Information about queues and agents and the ability to add queue members to a queue
        /// </summary>
        agent,

        /// <summary>
        /// Permission to send and receive UserEvent
        /// </summary>
        user,

        /// <summary>
        /// Ability to read and write configuration files
        /// </summary>
        config,

        /// <summary>
        /// Permission to run CLI commands. Write-only
        /// </summary>
        command,

        /// <summary>
        /// Receive DTMF events. Read-only
        /// </summary>
        dtmf,

        /// <summary>
        /// Ability to get information about the system
        /// </summary>
        reporting,

        /// <summary>
        /// Output of cdr_manager, if loaded. Read-only
        /// </summary>
        cdr,

        /// <summary>
        /// Receive NewExten and VarSet events. Read-only
        /// </summary>
        dialplan,

        /// <summary>
        /// Permission to originate new calls.Write-only
        /// </summary>
        originate,

        /// <summary>
        /// The item is associated with AGI execution
        /// </summary>
        agi,

        cc,
        aoc,
        test,
        message,
        security
    }
}
