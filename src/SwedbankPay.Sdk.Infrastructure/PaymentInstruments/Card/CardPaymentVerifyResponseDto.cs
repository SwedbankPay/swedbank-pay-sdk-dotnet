namespace SwedbankPay.Sdk.PaymentInstruments.Card;

internal class CardPaymentVerifyResponseDto
{
    public string Payment { get; set; }

    public CardPaymentVerifyResponseDetailsDto Verifications { get; set; }
}