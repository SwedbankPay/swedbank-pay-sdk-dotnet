namespace SwedbankPay.Sdk.PaymentOrders
{
    /// <summary>
    /// The items field of the paymentOrder is an array containing items that will affect how the payment is performed.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Insttanciates a <see cref="Item"/> with the provided parameters.
        /// </summary>
        /// <param name="creditCard">Credit card options.</param>
        /// <param name="invoice">Invoice options.</param>
        /// <param name="swish">Swish options.</param>
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