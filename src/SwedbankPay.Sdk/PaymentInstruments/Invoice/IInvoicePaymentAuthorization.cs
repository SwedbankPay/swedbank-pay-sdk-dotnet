namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    /// <summary>
    /// Wrapper for transactional details of a invocie authorization.
    /// </summary>
    public interface IInvoicePaymentAuthorization
    {
        /// <summary>
        /// Transactional details about this authorization.
        /// </summary>
        IAuthorizationTransaction Transaction { get; }
    }
}