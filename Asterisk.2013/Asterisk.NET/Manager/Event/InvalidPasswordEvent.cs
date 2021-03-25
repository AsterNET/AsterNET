using System;

namespace AsterNET.Manager.Event
{

    /// <summary>
    /// Raised when a request successfully authenticates with a service..<br />
    /// </summary>
    public class InvalidPasswordEvent : ManagerEvent
    {
        public const PrivilegeEnum Privilege = PrivilegeEnum.security;

        public InvalidPasswordEvent(ManagerConnection source)
            : base(source)
        {
        }

        public SeverityEnum Severity { get; set; }

        public string AccountId { get; set; }

        public string RemoteAddress { get; set; }

        public string Challenge { get; set; }
    }
}