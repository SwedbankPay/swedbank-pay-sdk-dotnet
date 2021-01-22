namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    /// <summary>
    /// Object for storing transactional details cancelling a invoice payment.
    /// </summary>
    public class InvoicePaymentCancelRequest
    {
        /// <summary>
        /// Instantiates a new <see cref="InvoicePaymentCancelRequest"/>
        /// with the provided <paramref name="transaction"/>.
        /// </summary>
        /// <param name="transaction">Transactional details about a
        /// invoice cancellation.</param>
        public InvoicePaymentCancelRequest(CancelTransaction transaction)
        {
            Transaction = transaction;
        }

        /// <summary>
        /// Details needed to cancel the current invoice payment.
        /// </summary>
        public CancelTransaction Transaction { get; }

    }
}