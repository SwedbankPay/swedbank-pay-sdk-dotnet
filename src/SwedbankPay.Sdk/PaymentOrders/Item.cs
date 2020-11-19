namespace SwedbankPay.Sdk.PaymentOrders
{
    /// <summary>
    /// The items field of the paymentOrder is an array containing items that will affect how the payment is performed.
    /// </summary>
    public class Item
    {
        public Item(CreditCard creditCard, Invoice invoice, Swish swish)
        {
            CreditCard = creditCard;
            Invoice = invoice;
            Swish = swish;
        }

        /// <summary>
        /// Object holding credit card specific options.
        /// </summary>
        public CreditCard CreditCard { get; }

        /// <summary>
        /// Object holding invoice specific options.
        /// </summary>
        public Invoice Invoice { get; }

        /// <summary>
        /// Object holding Swish specific options.
        /// </summary>
        public Swish Swish { get; }
    }
}