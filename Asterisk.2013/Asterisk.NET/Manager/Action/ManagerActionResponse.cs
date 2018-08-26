namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     The ManagerActionResponse is implemented by ManagerActions that
    ///     return their result in a custom ManagerResponse<br />
    ///     The response type that indicates that Asterisk is finished is returned by the
    ///     ActionCompleteResponseClass property.
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+AMI+Actions">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+AMI+Actions</see>
    /// </summary>
    /// <seealso cref="AsterNET.Manager.Event.ResponseEvent" />
    public abstract class ManagerActionResponse : ManagerAction
    {
        /// <summary>
        ///     Returns the response type that indicates that Asterisk is finished sending response for this action.
        /// </summary>
        /// <seealso cref="AsterNET.Manager.Response" />
        public abstract object ActionCompleteResponseClass();
    }
}