namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class InvoicePayment : IInvoicePayment
    {
        public InvoicePayment(InvoiceType invoiceType)
        {
            InvoiceType = invoiceType;
        }

        public InvoiceType InvoiceType { get; set; }
    }
}
