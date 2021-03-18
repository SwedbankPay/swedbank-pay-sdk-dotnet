using System.Net.Http;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPaymentRecurResponse : ICardPaymentRecurResponse
    {
        public CardPaymentRecurResponse(CardPaymentRecurResponseDto dto, HttpClient httpClient)
        {
            Payment = new CardPaymentRecurResponseDetails(dto.Payment);
            var operations = dto.Operations.Map();
            Operations = new CardPaymentOperations(operations, httpClient);
        }

        public ICardPaymentRecurResponseDetails Payment { get; }

        public ICardPaymentOperations Operations { get; }
    }
}