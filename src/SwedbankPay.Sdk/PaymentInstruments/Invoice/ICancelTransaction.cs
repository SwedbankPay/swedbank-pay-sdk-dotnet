namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    /// <summary>
    /// Perform the create-cancellation operation to cancel a previously authorized or partially captured invoice payment.
    /// </summary>
    public interface ICancelTransaction
    {
        /// <summary>
        /// The reason for the cancellation.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// The payeeReference is the receipt/invoice number, which is a unique reference with max 50 characters set by the merchant system.
        /// This must be unique for each operation and must follow the regex pattern [\w-]*.
        /// </summary>
        string PayeeReference { get; }

        /// <summary>
        /// FinancingConsumer
        /// </summary>
        Operation TransactionActivity { get; } 
    }
}