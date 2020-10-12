namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public interface ICardPaymentAuthorizationRequestTransaction1
    {
        int CardExpiryMonth { get; }
        int CardExpiryYear { get; }
        string CardHolderName { get; }
        string CardNumber { get; }
        string CardVerificationCode { get; }
    }
}