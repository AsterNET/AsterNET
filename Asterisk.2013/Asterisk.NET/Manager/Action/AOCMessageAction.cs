using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsterNET.Manager.Action
{
    public class AOCMessageAction : ManagerAction
    {

        private string _channel;
        private string _channelPrefix;
        private string _msgType;
        private string _chargeType;
        private int _unitAmount;
        private int _unitType;
        private string _currencyName;
        private string _currencyAmount;
        private string _currencyMultiplier;
        private string _totalType;
        private string _aocBillingId;
        private string _chargingAssociationId;
        private string _chargingAssociationNumber;
        private string _chargingrAssociationPlan;

        /// <summary>
        /// Generate an Advice of Charge message on a channel.
        /// </summary>
        public AOCMessageAction()
        {
        }

        /// <summary>
        /// Generate an Advice of Charge message on a channel.
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
        public AOCMessageAction(string channel, string channelPrefix, string msgType, string chargeType, int unitAmount, int unitType, string currencyName, string currencyAmount, string currencyMultiplier, string totalType, string aocBillingId, string chargingAssociationId, string chargingAssociationNumber, string chargingrAssociationPlan)
        {
            _channel = channel;
            _channelPrefix = channelPrefix;
            _msgType = msgType;
            _chargeType = chargeType;
            _unitAmount = unitAmount;
            _unitType = unitType;
            _currencyName = currencyName;
            _currencyAmount = currencyAmount;
            _currencyMultiplier = currencyMultiplier;
            _totalType = totalType;
            _aocBillingId = aocBillingId;
            _chargingAssociationId = chargingAssociationId;
            _chargingAssociationNumber = chargingAssociationNumber;
            _chargingrAssociationPlan = chargingrAssociationPlan;
        }

        public override string Action
        {
            get { return "AOCMessage"; }
        }

        public string Channel
        {
            get { return _channel; }
            set { _channel = value; }
        }

        public string ChannelPrefix
        {
            get { return _channelPrefix; }
            set { _channelPrefix = value; }
        }

        public string MsgType
        {
            get { return _msgType; }
            set { _msgType = value; }
        }

        public string ChargeType
        {
            get { return _chargeType; }
            set { _chargeType = value; }
        }

        public int UnitAmount
        {
            get { return _unitAmount; }
            set { _unitAmount = value; }
        }

        public int UnitType
        {
            get { return _unitType; }
            set { _unitType = value; }
        }

        public string CurrencyName
        {
            get { return _currencyName; }
            set { _currencyName = value; }
        }

        public string CurrencyAmount
        {
            get { return _currencyAmount; }
            set { _currencyAmount = value; }
        }

        public string CurrencyMultiplier
        {
            get { return _currencyMultiplier; }
            set { _currencyMultiplier = value; }
        }

        public string TotalType
        {
            get { return _totalType; }
            set { _totalType = value; }
        }

        public string AocBillingId
        {
            get { return _aocBillingId; }
            set { _aocBillingId = value; }
        }

        public string ChargingAssociationId
        {
            get { return _chargingAssociationId; }
            set { _chargingAssociationId = value; }
        }

        public string ChargingAssociationNumber
        {
            get { return _chargingAssociationNumber; }
            set { _chargingAssociationNumber = value; }
        }

        public string ChargingrAssociationPlan
        {
            get { return _chargingrAssociationPlan; }
            set { _chargingrAssociationPlan = value; }
        }
    }
}
