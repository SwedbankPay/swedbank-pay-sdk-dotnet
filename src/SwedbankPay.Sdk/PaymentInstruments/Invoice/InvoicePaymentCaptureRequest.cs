namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class InvoicePaymentCaptureRequest
    {
        public InvoicePaymentCaptureRequest(ICaptureTransaction transaction)
        {
            Transaction = transaction;
        }


        public ICaptureTransaction Transaction { get; }
    }
}