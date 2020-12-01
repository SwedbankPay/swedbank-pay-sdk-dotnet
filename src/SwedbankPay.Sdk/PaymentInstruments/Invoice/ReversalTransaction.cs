namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    /// <summary>
    /// Transactional details for reversing a invoice transaction.
    /// </summary>
    public class ReversalTransaction : IReversalTransaction
    {
        /// <summary>
        /// Instantiates a new <see cref="ReversalTransaction"/> using the provided parameters.
        /// </summary>
        /// <param name="amount">The <seealso cref="Sdk.Amount"/> to return to the payer.</param>
        /// <param name="vatAmount">The <seealso cref="Sdk.Amount"/> to return from the VAT amount.</param>
        /// <param name="description">A textual description of the reversal.</param>
        /// <param name="payeeReference">The payeeReference is the receipt/invoice number if receiptReference is not defined,
        /// which is a unique reference with max 50 characters set by the merchant system.
        /// This must be unique for each operation and must follow the regex pattern [\w-]*.</param>
        /// <param name="receiptReference">The receiptReference is a reference from the merchant system.
        /// This reference is used as an invoice/receipt number.</param>
        public ReversalTransaction(Amount amount, Amount vatAmount, string description, string payeeReference, string receiptReference)
        {
            Amount = amount;
            VatAmount = vatAmount;
            Description = description;
            PayeeReference = payeeReference;
            ReceiptReference = receiptReference;
        }

        public Amount Amount { get; }
        public string Description { get; }
        public string PayeeReference { get; }
        public Amount VatAmount { get; }

        public string ReceiptReference { get; }
    }
}