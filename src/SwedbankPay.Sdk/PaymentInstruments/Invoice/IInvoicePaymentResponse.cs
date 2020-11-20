namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
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