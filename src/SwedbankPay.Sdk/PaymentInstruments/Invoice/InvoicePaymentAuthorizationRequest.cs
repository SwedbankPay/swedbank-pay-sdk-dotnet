namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
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