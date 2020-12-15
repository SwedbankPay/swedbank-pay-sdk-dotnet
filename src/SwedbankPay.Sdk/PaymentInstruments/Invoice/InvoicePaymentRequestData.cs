namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    /// <summary>
    /// Wrapper for a <seealso cref="Invoice.InvoiceType"/>.
    /// </summary>
    public class InvoicePaymentRequestData : IInvoiceDetails
    {
        /// <summary>
        /// Instantiates a new <see cref="InvoicePaymentRequestData"/> with the provided <paramref name="invoiceType"/>.
        /// </summary>
        /// <param name="invoiceType">The type of invoice.</param>
        public InvoicePaymentRequestData(InvoiceType invoiceType)
        {
            InvoiceType = invoiceType;
        }

        /// <summary>
        /// The invoice type for the current payment.
        /// </summary>
        public InvoiceType InvoiceType { get; }
    }
}
