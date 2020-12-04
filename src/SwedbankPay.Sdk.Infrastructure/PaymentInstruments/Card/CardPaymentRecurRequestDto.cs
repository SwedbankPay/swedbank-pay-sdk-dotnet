namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPaymentRecurRequestDto
    {
        public CardPaymentRecurRequestDto(CardPaymentRecurRequest paymentRequest)
        {
            Payment = new CardPaymentRecurPaymentDto(paymentRequest.Payment);
        }

        public CardPaymentRecurPaymentDto Payment { get; }
    }
}