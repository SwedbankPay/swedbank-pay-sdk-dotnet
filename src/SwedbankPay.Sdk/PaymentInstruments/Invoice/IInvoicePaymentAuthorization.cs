namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public interface IInvoicePaymentAuthorization
    {
        IAuthorizationTransaction Transaction { get; }
    }
}