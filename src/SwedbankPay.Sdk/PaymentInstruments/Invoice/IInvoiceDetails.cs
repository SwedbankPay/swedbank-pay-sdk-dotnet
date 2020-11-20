namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public interface IInvoiceDetails
    {
        /// <summary>
        /// The type this invoice was created with.
        /// </summary>
        InvoiceType InvoiceType { get; set; }
    }
}