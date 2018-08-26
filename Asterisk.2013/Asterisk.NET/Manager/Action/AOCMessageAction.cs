namespace AsterNET.Manager.Action
{
    public class AOCMessageAction : ManagerAction
    {
        /// <summary>
        ///     Generate an Advice of Charge message on a channel.
        ///     
        ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_AOCMessage">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_AOCMessage</see>
        /// </summary>
        public AOCMessageAction()
        {
        }

        /// <summary>
        ///     Generate an Advice of Charge message on a channel.
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
        /// <param name="chargingrAssociationPlan"></param>
        public AOCMessageAction(string channel, string channelPrefix, string msgType, string chargeType, int unitAmount,
            int unitType, string currencyName, string currencyAmount, string currencyMultiplier, string totalType,
            string aocBillingId, string chargingAssociationId, string chargingAssociationNumber,
            string chargingrAssociationPlan)
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
            ChargingrAssociationPlan = chargingrAssociationPlan;
        }

        public override string Action
        {
            get { return "AOCMessage"; }
        }

        public string Channel { get; set; }

        public string ChannelPrefix { get; set; }

        public string MsgType { get; set; }

        public string ChargeType { get; set; }

        public int UnitAmount { get; set; }

        public int UnitType { get; set; }

        public string CurrencyName { get; set; }

        public string CurrencyAmount { get; set; }

        public string CurrencyMultiplier { get; set; }

        public string TotalType { get; set; }

        public string AocBillingId { get; set; }

        public string ChargingAssociationId { get; set; }

        public string ChargingAssociationNumber { get; set; }

        public string ChargingrAssociationPlan { get; set; }
    }
}