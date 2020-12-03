using System.Net.Http;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPaymentResponse : ICardPaymentResponse
    {
        internal CardPaymentResponse(CardPaymentResponseDto cardPaymentResponseDto, HttpClient httpClient)
        {
            Operations = new CardPaymentOperations(cardPaymentResponseDto.Operations.Map(), httpClient);
            Payment = new CardPayment(cardPaymentResponseDto.Payment);
        }

        public ICardPaymentOperations Operations { get; set; }

        public ICardPayment Payment { get; set; }
    }
}