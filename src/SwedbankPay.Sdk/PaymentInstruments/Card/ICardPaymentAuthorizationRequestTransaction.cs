namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public interface ICardPaymentAuthorizationRequestTransaction
    {
        int CardExpiryMonth { get; }
        int CardExpiryYear { get; }
        string CardHolderName { get; }
        string CardNumber { get; }
        string CardVerificationCode { get; }
    }
}