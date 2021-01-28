using System.Net.Http;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPaymentResponseDto
    {
        public OperationListDto Operations { get; set; }

        public CardPaymentDto Payment { get; set; }

        public ICardPaymentResponse Map(HttpClient httpClient)
        {
            return new CardPaymentResponse(this, httpClient);
        }
    }
}