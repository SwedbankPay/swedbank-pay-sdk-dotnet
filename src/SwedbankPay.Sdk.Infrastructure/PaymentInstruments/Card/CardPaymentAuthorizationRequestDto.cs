namespace SwedbankPay.Sdk.PaymentInstruments.Card;

internal class CardPaymentAuthorizationRequestDto
{
    public CardPaymentAuthorizationRequestDto(CardPaymentAuthorizationRequest payload)
    {
        Transaction = new CardPaymentCardDetailsDto(payload.Transaction);
    }

    public CardPaymentCardDetailsDto Transaction { get; }
}