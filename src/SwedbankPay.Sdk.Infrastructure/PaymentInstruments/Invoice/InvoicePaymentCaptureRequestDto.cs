namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    internal class InvoicePaymentCaptureRequestDto
    {
        public InvoicePaymentCaptureRequestDto(InvoicePaymentCaptureRequest payload)
        {
            Transaction = new InvoicePaymentCaptureRequestDetailsDto(payload.Transaction);
        }

        public InvoicePaymentCaptureRequestDetailsDto Transaction { get; }
    }
}