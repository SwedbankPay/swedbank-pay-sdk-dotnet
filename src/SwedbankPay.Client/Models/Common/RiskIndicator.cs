namespace SwedbankPay.Client.Models.Common
{
    public class RiskIndicator
    {
        /// <summary>
        /// For electronic delivery, the email address to which the merchandise was delivered.
        /// </summary>
        public string DeliveryEmailAddress { get; set; }

        /// <summary>
        /// Indicates the merchandise delivery timeframe.
        /// 01 (Electronic Delivery)
        /// 02 (Same day shipping)
        /// 03 (Overnight shipping)
        /// 04 (Two-day or more shipping)
        /// </summary>
        public string DeliveryTimeFrameIndicator { get; set; } //TODO use DeliveryTimeFrameIndicator class?

        /// <summary>
        /// For a pre-ordered purchase. The expected date that the merchandise will be available.
        /// FORMAT: "YYYYMMDD"
        /// </summary>
        public string PreOrderDate { get; set; }

        /// <summary>
        /// Indicates whether Cardholder is placing an order for merchandise with a future availability or release date.
        /// 01 (Merchandise available)
        /// 02 (Future availability)
        /// </summary>
        public string PreOrderPurchaseIndicator { get; set; }

        /// <summary>
        /// Indicates shipping method chosen for the transaction.
        /// 01 (Ship to cardholder's billing address)
        /// 02 (Ship to another verified address on file with merchant)
        /// 03 (Ship to address that is different than cardholder's billing address)
        /// 04 (Ship to Store / Pick-up at local store.Store address shall be populated in shipping address fields)
        /// 05 (Digital goods, includes online services, electronic giftcards and redemption codes)
        /// 06 (Travel and Event tickets, not shipped)
        /// 07 (Other, e.g.gaming, digital service)
        /// </summary>
        public string ShipIndicator { get; set; }

        /// <summary>
        /// true if this is a purchase of a gift card.
        /// </summary>
        public bool GiftCardPurchase { get; set; }

        /// <summary>
        /// Indicates whether Cardholder is placing an order for merchandise with a future availability or release date.
        /// 01 (Merchandise available)
        /// 02 (Future availability)
        /// </summary>
        public string ReOrderPurchaseIndicator { get; set; }

        /// <summary>
        /// If shipIndicator set to 4, then prefil this.
        /// </summary>
        public PickUpAddress PickUpAddress { get; set; }
        

    }
    
}