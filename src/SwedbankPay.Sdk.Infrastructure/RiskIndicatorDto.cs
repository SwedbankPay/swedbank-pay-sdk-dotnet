using SwedbankPay.Sdk.PaymentInstruments.Card;
using SwedbankPay.Sdk.PaymentOrders;
using System;

namespace SwedbankPay.Sdk
{
    internal class RiskIndicatorDto
    {
        private const string ThreeDSecureDateTimeString = "yyyyMMdd";

        public RiskIndicatorDto(IRiskIndicator riskIndicator)
        {
            if (riskIndicator == null)
            {
                return;
            }

            DeliveryEmailAddress = riskIndicator.DeliveryEmailAddress.ToString();
            DeliveryTimeFrameIndicator = riskIndicator.DeliveryTimeFrameIndicator.Value;
            GiftCardPurchase = riskIndicator.GiftCardPurchase;
            PickUpAddress = new AddressDto(riskIndicator.PickUpAddress);
            PreOrderDate = riskIndicator.PreOrderDate.ToString(ThreeDSecureDateTimeString);
            PreOrderPurchaseIndicator = riskIndicator.PreOrderPurchaseIndicator.Value;
            ReOrderPurchaseIndicator = riskIndicator.ReOrderPurchaseIndicator.Value;
            ShipIndicator = riskIndicator.ShipIndicator.Value;
        }

        public string DeliveryEmailAddress { get; set; }

        public string DeliveryTimeFrameIndicator { get; set; }

        public bool GiftCardPurchase { get; set; }

        public AddressDto PickUpAddress { get; set; }

        public string PreOrderDate { get; set; }

        public string PreOrderPurchaseIndicator { get; set; }

        public string ReOrderPurchaseIndicator { get; set; }

        public string ShipIndicator { get; set; }
    }
}