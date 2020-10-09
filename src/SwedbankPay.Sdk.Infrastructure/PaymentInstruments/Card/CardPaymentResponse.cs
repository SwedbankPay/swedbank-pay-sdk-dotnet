using SwedbankPay.Sdk.Payments.CardPayments;
using System.Net.Http;

namespace SwedbankPay.Sdk.Payments
{
    public class CardPaymentResponse : ICardPaymentResponse
    {
        internal CardPaymentResponse(CardPaymentResponseDto cardPaymentResponseDto, HttpClient httpClient)
        {
            this.Operations = new CardPaymentOperations(cardPaymentResponseDto.Operations, httpClient);
            this.Payment = new CardPayment(cardPaymentResponseDto.Payment);
        }

        public ICardPaymentOperations Operations { get; set; }

        public ICardPayment Payment { get; set; }
    }
}