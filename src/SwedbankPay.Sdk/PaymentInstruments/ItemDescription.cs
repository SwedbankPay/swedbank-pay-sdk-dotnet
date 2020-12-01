namespace SwedbankPay.Sdk.PaymentInstruments
{
    /// <summary>
    /// Object wrapping description of an purchasable item.
    /// </summary>
    public class ItemDescription
    {
        /// <summary>
        /// Instantiates a new <see cref="ItemDescription"/> with the provided parameters.
        /// </summary>
        /// <param name="amount">The <seealso cref="Sdk.Amount"/> the payer will pay for this item.</param>
        /// <param name="description">A textual description of this item.</param>
        public ItemDescription(Amount amount,
                                string description)
        {
            Amount = amount;
            Description = description;
        }

        /// <summary>
        /// The <seealso cref="Sdk.Amount"/> the payer will pay for this item.
        /// </summary>
        public Amount Amount { get; }

        /// <summary>
        /// A textual description of the item.
        /// </summary>
        public string Description { get; }

    }
}
