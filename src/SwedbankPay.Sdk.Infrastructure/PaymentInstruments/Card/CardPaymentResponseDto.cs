using System.Net.Http;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CardPaymentResponseDto
    {
        public OperationListDto Operations { get; set; }

        public CardPaymentDto Payment { get; set; }

        public ICardPaymentResponse Map(HttpClient httpClient)
        {
            return new CardPaymentResponse(this, httpClient);
        }
    }
}