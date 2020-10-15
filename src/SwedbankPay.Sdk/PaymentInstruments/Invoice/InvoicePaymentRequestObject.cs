namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class InvoicePaymentRequestObject : IInvoicePaymentRequestObject
    {
        protected internal InvoicePaymentRequestObject(InvoiceType invoiceType)
        {
            InvoiceType = invoiceType;
        }
        public InvoiceType InvoiceType { get; set; }

    }
}
