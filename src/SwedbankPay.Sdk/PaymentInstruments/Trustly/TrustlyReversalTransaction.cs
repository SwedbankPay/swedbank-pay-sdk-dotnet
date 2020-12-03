namespace SwedbankPay.Sdk.PaymentInstruments.Trustly
{
    /// <summary>
    /// API details for reversing funds of a Trustly payment.
    /// </summary>
    public class TrustlyReversalTransaction
    {
        /// <summary>
        /// Instantiates a <see cref="TrustlyReversalTransaction"/> with the provided parameters.
        /// </summary>
        /// <param name="operation">The API operation to use.</param>
        /// <param name="amount">The amount to refund back to the payer.</param>
        /// <param name="vatAmount">The amount of VAT to refund back to the payer.</param>
        /// <param name="payeeReference"></param>
        /// <param name="receiptReference"></param>
        /// <param name="description"></param>
        public TrustlyReversalTransaction(Operation operation, Amount amount, Amount vatAmount, string payeeReference, string receiptReference, string description)
        {
            TransactionActivity = operation;
            Amount = amount;
            VatAmount = vatAmount;
            Description = description;
            PayeeReference = payeeReference;
            RecepitReference = receiptReference;
        }

        /// <summary>
        /// The API operation to perform.
        /// </summary>
        public Operation TransactionActivity { get; }

        /// <summary>
        /// The <seealso cref="Sdk.Amount"/> (including VAT, if any) to charge the payer, entered in the selected currency.
        /// </summary>
        public Amount Amount { get; }

        /// <summary>
        /// A textual description of the reversal.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// The payeeReference is the receipt/invoice number if receiptReference is not defined,
        /// which is a unique reference with max 50 characters set by the merchant system.
        /// This must be unique for each operation and must follow the regex pattern [\w-]*.
        /// </summary>
        public string PayeeReference { get; }

        /// <summary>
        /// Reference from the merchant system. This reference is used as an invoice/receipt number.
        /// </summary>
        public string RecepitReference { get; }

        /// <summary>
        /// The payment’s VAT (Value Added Tax) amount, entered in the selected currency.
        /// The vatAmount entered will not affect the amount shown on the payment page,
        /// which only shows the total amount.
        /// This field is used to specify how much ofthe total amount the VAT will be.
        /// Set to 0 (zero) if there is no VAT amount charged.
        /// </summary>
        public Amount VatAmount { get; }
    }
}
