namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPaymentAbortRequestDto
    {
        public CardPaymentAbortRequestDto(CardPaymentAbortRequest payload)
        {
            Payment = new CardPaymentAbortDto(payload.Payment);
        }

        public CardPaymentAbortDto Payment { get; }
    }
}