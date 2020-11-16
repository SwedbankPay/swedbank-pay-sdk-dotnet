namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public class SwishPaymentReversalTransaction
    {
        public SwishPaymentReversalTransaction(Amount amount, Amount vatAmount, string description, string payeeReference)
        {
            Amount = amount;
            VatAmount = vatAmount;
            Description = description;
            PayeeReference = payeeReference;
        }

        /// <summary>
        /// The <seealso cref="Sdk.Amount"/> to reverse.
        /// </summary>
        public Amount Amount { get; }

        /// <summary>
        /// A textual description of the reversal.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// A unique reference from the merchant system.
        /// It is set per operation to ensure an exactly-once delivery of a transactional operation.
        /// </summary>
        public string PayeeReference { get; }

        /// <summary>
        /// The payment’s VAT (Value Added Tax) <seealso cref="Sdk.Amount"/> monetary unit of the selected currency.
        /// The vatAmount entered will not affect the amount shown on the payment page, which only shows the total amount.
        /// This field is used to specify how much ofthe total amount the VAT will be. Set to 0 (zero) if there is no VAT amount charged.
        /// </summary>
        public Amount VatAmount { get; }
    }
}