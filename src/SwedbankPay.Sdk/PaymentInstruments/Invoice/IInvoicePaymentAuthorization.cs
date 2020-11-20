namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public interface IInvoicePaymentAuthorization
    {
        /// <summary>
        /// Transactional details about this authorization.
        /// </summary>
        IAuthorizationTransaction Transaction { get; }
    }
}