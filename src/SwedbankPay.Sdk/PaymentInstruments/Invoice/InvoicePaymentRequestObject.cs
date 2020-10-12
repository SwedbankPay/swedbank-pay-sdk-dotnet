namespace SwedbankPay.Sdk.Payments.InvoicePayments
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
}