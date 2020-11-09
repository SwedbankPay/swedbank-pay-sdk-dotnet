namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class InvoicePaymentRequestObject : IInvoicePaymentRequestObject
    {
        public InvoicePaymentRequestObject(InvoiceType invoiceType)
        {
            InvoiceType = invoiceType;
        }

        public InvoiceType InvoiceType { get; set; }
    }
}
