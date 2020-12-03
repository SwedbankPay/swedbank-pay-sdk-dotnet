namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    /// <summary>
    /// Transactional details for capturing a Vipps payment.
    /// </summary>
    public class VippsPaymentCaptureTransaction
    {
        /// <summary>
        /// Instantiates a <see cref="VippsPaymentCaptureTransaction"/> with the provided parameters.
        /// </summary>
        /// <param name="amount">The amount of funds to capture.</param>
        /// <param name="vatAmount">The amount of funds to capture as value added taxes.</param>
        /// <param name="description">A textual description of the payment.</param>
        /// <param name="payeeReference">Transactionally unique reference to this capture transaction.</param>
        protected internal VippsPaymentCaptureTransaction(Amount amount,
                                                Amount vatAmount,
                                                string description,
                                                string payeeReference)
        {
            Amount = amount;
            VatAmount = vatAmount;
            Description = description;
            PayeeReference = payeeReference;
        }

        /// <summary>
        /// The <seealso cref="Sdk.Amount"/> (including VAT, if any) to charge the payer, entered in the selected currency.
        /// </summary>
        public Amount Amount { get; }

        /// <summary>
        /// Textual description of the payment.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// A unique reference from the merchant system.
        /// It is set per operation to ensure an exactly-once delivery of a transactional operation.
        /// </summary>
        public string PayeeReference { get; }

        /// <summary>
        /// The payment’s VAT (Value Added Tax) amount, entered in the lowest monetary unit of the selected currency.
        /// The vatAmount entered will not affect the amount shown on the payment page, which only shows the total amount.
        /// This field is used to specify how much ofthe total amount the VAT will be.
        /// Set to 0 (zero) if there is no VAT amount charged.
        /// </summary>
        public Amount VatAmount { get; }
    }
}
