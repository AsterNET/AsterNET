namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     Generate an Advice of Charge message on a channel.
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_AOCMessage">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_AOCMessage</see>
    /// </summary>
    public class AOCMessageAction : ManagerAction
    {
        /// <summary>
        ///     Creates a new empty <see cref="AOCMessageAction"/>.
        /// </summary>
        public AOCMessageAction()
        {
        }

        /// <summary>
        ///     Creates a new <see cref="AOCMessageAction"/>.
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="channelPrefix"></param>
        /// <param name="msgType"></param>
        /// <param name="chargeType"></param>
        /// <param name="unitAmount"></param>
        /// <param name="unitType"></param>
        /// <param name="currencyName"></param>
        /// <param name="currencyAmount"></param>
        /// <param name="currencyMultiplier"></param>
        /// <param name="totalType"></param>
        /// <param name="aocBillingId"></param>
        /// <param name="chargingAssociationId"></param>
        /// <param name="chargingAssociationNumber"></param>
        /// <param name="chargingAssociationPlan"></param>
        public AOCMessageAction(string channel, string channelPrefix, string msgType, string chargeType, int unitAmount,
            int unitType, string currencyName, string currencyAmount, string currencyMultiplier, string totalType,
            string aocBillingId, string chargingAssociationId, string chargingAssociationNumber,
            string chargingAssociationPlan)
        {
            Channel = channel;
            ChannelPrefix = channelPrefix;
            MsgType = msgType;
            ChargeType = chargeType;
            UnitAmount = unitAmount;
            UnitType = unitType;
            CurrencyName = currencyName;
            CurrencyAmount = currencyAmount;
            CurrencyMultiplier = currencyMultiplier;
            TotalType = totalType;
            AocBillingId = aocBillingId;
            ChargingAssociationId = chargingAssociationId;
            ChargingAssociationNumber = chargingAssociationNumber;
            ChargingAssociationPlan = chargingAssociationPlan;
        }

        /// <summary>
        ///     Get the name of this action, i.e. "AOCMessage".
        /// </summary>
        public override string Action
        {
            get { return "AOCMessage"; }
        }

        /// <summary>
        /// Gets or sets the channel.
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        /// Gets or sets the channel prefix.
        /// </summary>
        public string ChannelPrefix { get; set; }

        /// <summary>
        /// Gets or sets the type of the MSG.
        /// </summary>
        public string MsgType { get; set; }

        /// <summary>
        /// Gets or sets the type of the charge.
        /// </summary>
        public string ChargeType { get; set; }

        /// <summary>
        /// Gets or sets the unit amount.
        /// </summary>
        public int UnitAmount { get; set; }

        /// <summary>
        /// Gets or sets the type of the unit.
        /// </summary>
        public int UnitType { get; set; }

        /// <summary>
        /// Gets or sets the name of the currency.
        /// </summary>
        public string CurrencyName { get; set; }

        /// <summary>
        /// Gets or sets the currency amount.
        /// </summary>
        public string CurrencyAmount { get; set; }

        /// <summary>
        /// Gets or sets the currency multiplier.
        /// </summary>
        public string CurrencyMultiplier { get; set; }

        /// <summary>
        /// Gets or sets the total type.
        /// </summary>
        public string TotalType { get; set; }

        /// <summary>
        /// Gets or sets the aoc billing identifier.
        /// </summary>
        public string AocBillingId { get; set; }

        /// <summary>
        /// Gets or sets the charging association identifier.
        /// </summary>
        public string ChargingAssociationId { get; set; }

        /// <summary>
        /// Gets or sets the charging association number.
        /// </summary>
        public string ChargingAssociationNumber { get; set; }

        /// <summary>
        /// Gets or sets the charging association plan.
        /// </summary>
        public string ChargingAssociationPlan { get; set; }
    }
}