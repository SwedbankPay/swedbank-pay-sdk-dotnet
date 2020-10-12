namespace SwedbankPay.Sdk.Payments.InvoicePayments
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