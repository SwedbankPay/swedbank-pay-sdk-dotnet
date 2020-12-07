namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPaymentAbortRequestDto
    {
        public CardPaymentAbortRequestDto(CardPaymentAbortRequest payload)
        {
            Payment = new CardPaymentAbortPaymentDto(payload.Payment);
        }

        public CardPaymentAbortPaymentDto Payment { get; }
    }
}