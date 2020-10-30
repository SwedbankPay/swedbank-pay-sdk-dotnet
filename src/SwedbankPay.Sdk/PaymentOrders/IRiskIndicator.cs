using SwedbankPay.Sdk.Common;
using System;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public interface IRiskIndicator
    {
        EmailAddress DeliveryEmailAddress { get; set; }
        DeliveryTimeFrameIndicator DeliveryTimeFrameIndicator { get; set; }
        bool GiftCardPurchase { get; set; }
        PickUpAddress PickUpAddress { get; set; }
        DateTime PreOrderDate { get; set; }
        PreOrderPurchaseIndicator PreOrderPurchaseIndicator { get; set; }
        ReOrderPurchaseIndicator ReOrderPurchaseIndicator { get; set; }
        ShipIndicator ShipIndicator { get; set; }
    }
}