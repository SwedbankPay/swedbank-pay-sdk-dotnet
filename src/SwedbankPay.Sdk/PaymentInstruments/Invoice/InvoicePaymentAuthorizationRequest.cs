namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    /// <summary>
    /// Object for storing a authorization request to the invoice API.
    /// </summary>
    public class InvoicePaymentAuthorizationRequest
    {
        /// <summary>
        /// Instantiates a new <see cref="InvoicePaymentAuthorizationRequest"/>
        /// with the provided <paramref name="transaction"/>.
        /// </summary>
        /// <param name="transaction">Transactional details about a invoice authorization.</param>
        public InvoicePaymentAuthorizationRequest(IAuthorizationTransaction transaction)
        {
            Transaction = transaction;
        }

        /// <summary>
        /// Details needed to authorize this payment.
        /// </summary>
        public IAuthorizationTransaction Transaction { get; }
    }
}