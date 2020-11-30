namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    /// <summary>
    /// Object holding the details needed to capture a invoice payment.
    /// </summary>
    public class InvoicePaymentCaptureRequest
    {
        /// <summary>
        /// Instantiates a new <see cref="InvoicePaymentCaptureRequest"/> with
        /// the provided <paramref name="transaction"/>.
        /// </summary>
        /// <param name="transaction">Transactional details needed to capture a invoice payment.</param>
        public InvoicePaymentCaptureRequest(ICaptureTransaction transaction)
        {
            Transaction = transaction;
        }

        /// <summary>
        /// Details needed to capture the current payment.
        /// </summary>
        public ICaptureTransaction Transaction { get; }
    }
}