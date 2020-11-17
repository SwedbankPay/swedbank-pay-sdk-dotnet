namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class ItemDescriptions
    {
        public ItemDescriptions(Amount amount,
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
