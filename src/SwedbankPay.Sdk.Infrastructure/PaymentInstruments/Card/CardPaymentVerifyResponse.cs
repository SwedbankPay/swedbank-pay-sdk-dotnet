namespace SwedbankPay.Sdk.PaymentInstruments.Card;

internal class CardPaymentVerifyResponse : Identifiable, ICardPaymentVerifyResponse
{
    public CardPaymentVerifyResponse(CardPaymentVerifyResponseDto dto)
        : base(dto.Payment)
    {
        Verifications = dto.Verifications.Map();
    }

    public IVerificationListResponse Verifications { get; }
}
