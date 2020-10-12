namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public interface ICardPaymentAuthorizationRequest
    {
        ICardPaymentAuthorizationRequestTransaction Transaction { get; }
    }
}