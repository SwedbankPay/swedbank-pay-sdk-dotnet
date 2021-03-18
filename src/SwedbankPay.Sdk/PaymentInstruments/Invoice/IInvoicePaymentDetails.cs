namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    /// <summary>
    /// Transactional details about a invoice payment.
    /// </summary>
    public interface IInvoicePaymentDetails : IIdentifiable, IPaymentInstrument
    {
        /// <summary>
        /// Gets the available authorizations on this invoice.
        /// </summary>
        IInvoicePaymentAuthorizationListResponse Authorizations { get; }
    }
}