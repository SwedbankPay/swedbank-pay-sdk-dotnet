namespace SwedbankPay.Sdk.PaymentInstruments.Card;

internal class CardPaymentVerifyRequestDto
{
    public CardPaymentVerifyRequestDto(CardPaymentVerifyRequest paymentRequest)
    {
        Payment = new CardPaymentVerifyRequestDetailsDto(paymentRequest.Payment);
    }

    public CardPaymentVerifyRequestDetailsDto Payment { get; }
}