namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class InvoicePaymentResponseDto
    {
        public PaymentOperationsDto Operations { get; internal set; }

        public InvoicePaymentDto Payment { get; set; }
    }
}