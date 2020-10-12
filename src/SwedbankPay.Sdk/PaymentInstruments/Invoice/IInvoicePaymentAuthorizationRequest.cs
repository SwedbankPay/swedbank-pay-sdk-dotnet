namespace SwedbankPay.Sdk.Payments.InvoicePayments
{
    public interface IInvoicePaymentAuthorizationRequest
    {
        IAuthorizationTransaction Transaction { get; }
    }
}