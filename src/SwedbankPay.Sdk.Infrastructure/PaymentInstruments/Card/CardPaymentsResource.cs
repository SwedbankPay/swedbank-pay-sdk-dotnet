using SwedbankPay.Sdk.Extensions;
using SwedbankPay.Sdk.Payments.CardPayments;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments
{
    public class CardPaymentsResource : ResourceBase, ICardResource
    {
        public CardPaymentsResource(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<ICardPaymentResponse> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            Uri url = GetUrlWithQueryString(id, paymentExpand);

            var cardPaymentResponseDto = await HttpClient.GetAsJsonAsync<CardPaymentResponseDto>(url);
            return new CardPaymentResponse(cardPaymentResponseDto, HttpClient);
        }


        public async Task<ICardPaymentResponse> Create(CardPaymentRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            var url = new Uri($"/psp/creditcard/payments{paymentExpand}", UriKind.Relative);

            var cardPaymentResponseDto = await HttpClient.PostAsJsonAsync<CardPaymentResponseDto>(GetUrlWithQueryString(url, paymentExpand), paymentRequest);
            return new CardPaymentResponse(cardPaymentResponseDto, HttpClient);
        }

        private Uri GetUrlWithQueryString(Uri id, PaymentExpand paymentExpand)
        {
            var paymentExpandQueryString = GetExpandQueryString(paymentExpand);
            var url = !string.IsNullOrWhiteSpace(paymentExpandQueryString)
                ? new Uri(id.OriginalString + paymentExpandQueryString, UriKind.RelativeOrAbsolute)
                : id;
            return url;
        }
    }
}
