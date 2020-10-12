namespace SwedbankPay.Sdk.Payments.InvoicePayments
{
    public class InvoicePaymentAuthorizationRequest
    {
        public InvoicePaymentAuthorizationRequest(IAuthorizationTransaction transaction)
        {
            Transaction = transaction;
        }


        public IAuthorizationTransaction Transaction { get; }
}
}