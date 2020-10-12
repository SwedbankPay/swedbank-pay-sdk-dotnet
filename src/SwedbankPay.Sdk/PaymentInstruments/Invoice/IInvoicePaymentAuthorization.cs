namespace SwedbankPay.Sdk.Payments.InvoicePayments
{
    public interface IInvoicePaymentAuthorization
    {
        IAuthorizationTransaction Transaction { get; }
    }
}