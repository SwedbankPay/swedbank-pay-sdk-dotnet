namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class InvoicePaymentAuthorizationRequest
    {
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