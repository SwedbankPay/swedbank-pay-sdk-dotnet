namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class InvoicePaymentCaptureRequest
    {
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