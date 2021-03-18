namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPaymentRecurRequestDto
    {
        public CardPaymentRecurRequestDto(CardPaymentRecurRequest paymentRequest)
        {
            Payment = new CardPaymentRecurDto(paymentRequest.Payment);
        }

        public CardPaymentRecurDto Payment { get; }
    }
}