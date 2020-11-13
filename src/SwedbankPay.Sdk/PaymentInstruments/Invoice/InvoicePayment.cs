namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class InvoicePayment : IInvoicePayment
    {
        public InvoicePayment(InvoiceType invoiceType)
        {
            InvoiceType = invoiceType;
        }

        /// <summary>
        /// The invoice type for the current payment.
        /// </summary>
        public InvoiceType InvoiceType { get; set; }
    }
}
