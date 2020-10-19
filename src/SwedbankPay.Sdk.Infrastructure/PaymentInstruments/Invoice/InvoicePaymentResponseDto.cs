namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class InvoicePaymentResponseDto
    {
        public OperationListDto Operations { get; internal set; }

        public InvoicePaymentDto Payment { get; set; }
    }
}