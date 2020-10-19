using System.Net.Http;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CardPaymentResponse : ICardPaymentResponse
    {
        internal CardPaymentResponse(CardPaymentResponseDto cardPaymentResponseDto, HttpClient httpClient)
        {
            Operations = new CardPaymentOperations(cardPaymentResponseDto.Operations, httpClient);
            Payment = new CardPayment(cardPaymentResponseDto.Payment);
        }

        public ICardPaymentOperations Operations { get; set; }

        public ICardPayment Payment { get; set; }
    }
}