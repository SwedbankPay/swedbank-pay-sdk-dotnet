namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class InvoicePaymentAuthorization : IdLink, IInvoicePaymentAuthorization
    {
        public InvoicePaymentAuthorization(
                             AuthorizationTransaction transaction)
        {
            Transaction = transaction;
        }

        public IAuthorizationTransaction Transaction { get; }
    }
}