namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    /// <summary>
    /// Object holding the current invoice payment details
    /// and available operations for that invoice.
    /// </summary>
    public interface IInvoicePaymentResponse
    {
        /// <summary>
        /// The data and details about the current invoice payment.
        /// </summary>
        IInvoicePaymentDetails Payment { get; }

        /// <summary>
        /// The currently available operations on this invoice payment.
        /// </summary>
        IInvoicePaymentOperations Operations { get; }
    }
}