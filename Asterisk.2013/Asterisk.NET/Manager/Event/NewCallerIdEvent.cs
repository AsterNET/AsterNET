using System;

namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     A NewCallerIdEvent is triggered when the caller id of a channel changes.<br />
    ///     It is implemented in channel.c<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_NewCallerid">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_NewCallerid</see>
    /// </summary>
    public class NewCallerIdEvent : ManagerEvent
    {
        private int cidCallingPres;
        private string cidCallingPresTxt;

        /// <summary>
        ///     Creates a new <see cref="NewCallerIdEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public NewCallerIdEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        ///     Get/Set the new caller id.
        /// </summary>
        public string CallerId { get; set; }

        /// <summary>
        ///     Get/Set the new Caller*ID Name if set or "&lt;Unknown&gt;" if none has been set.
        /// </summary>
        public string CallerIdName { get; set; }

        /// <summary>
        ///     Get/Set the new Caller*ID Numb.
        /// </summary>
        public string CallerIdNum { get; set; }

        /// <summary>
        ///     Get the CallerId presentation/screening.
        /// </summary>
        public int CidCallingPresNumeric
        {
            get { return cidCallingPres; }
        }

        /// <summary>
        ///     Get/Sets the CallerId presentation/screening in the form "%d (%s)".
        /// </summary>
        public string CidCallingPres
        {
            get { return cidCallingPres + " (" + cidCallingPresTxt + ")"; }
            set
            {
                string s = value;
                if (s == null || s.Length == 0)
                    return;

                int spaceIdx = s.IndexOf(' ');
                if (spaceIdx <= 0)
                    spaceIdx = s.Length;
                try
                {
                    cidCallingPres = int.Parse(s.Substring(0, spaceIdx));
                }
                catch (FormatException)
                {
                    return;
                }
                if (s.Length > spaceIdx + 3)
                    cidCallingPresTxt = s.Substring(spaceIdx + 2, (s.Length - 1) - (spaceIdx + 2));
            }
        }
    }
}