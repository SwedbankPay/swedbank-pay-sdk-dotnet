using System;

namespace SwedbankPay.Sdk
{
    /// <summary>
    /// Risk indicator object for 3D Secure 2.0 risk assessment.
    /// </summary>
    public interface IRiskIndicator
    {
        /// <summary>
        /// Payers delivery email address.
        /// </summary>
        EmailAddress DeliveryEmailAddress { get; set; }

        /// <summary>
        /// Indicates the merchandise delivery timeframe. 
        /// </summary>
        DeliveryTimeFrameIndicator DeliveryTimeFrameIndicator { get; set; }

        /// <summary>
        /// Set if this is a gift card purchase.
        /// </summary>
        bool GiftCardPurchase { get; set; }

        /// <summary>
        /// If shipIndicator set to <seealso cref="DeliveryTimeFrameIndicator.TwoDayOrMoreShipping"/>,
        /// then prefill this with the payers pick up address of the purchase to decrease the risk factor of the purchase.
        /// </summary>
        PickUpAddress PickUpAddress { get; set; }

        /// <summary>
        /// For a pre-ordered purchase. The expected date that the merchandise will be available.
        /// </summary>
        DateTime PreOrderDate { get; set; }

        /// <summary>
        /// Indicates whether the payer is placing an order for merchandise with a future availability or release date.
        /// </summary>
        PreOrderPurchaseIndicator PreOrderPurchaseIndicator { get; set; }

        /// <summary>
        /// Indicates whether the cardholder is reordering previously purchased merchandise. 
        /// </summary>
        ReOrderPurchaseIndicator ReOrderPurchaseIndicator { get; set; }

        /// <summary>
        /// Indicates shipping method chosen for the transaction. 
        /// </summary>
        ShipIndicator ShipIndicator { get; set; }
    }
}