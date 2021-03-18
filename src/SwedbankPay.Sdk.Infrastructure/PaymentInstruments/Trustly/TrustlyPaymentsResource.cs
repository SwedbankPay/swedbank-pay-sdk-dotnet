using SwedbankPay.Sdk.Extensions;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentInstruments.Trustly
{
    public class TrustlyPaymentsResource : ResourceBase, ITrustlyResource
    {
        public TrustlyPaymentsResource(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<ITrustlyPaymentResponse> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            Uri url = id.GetUrlWithQueryString(paymentExpand);

            var paymentResponse = await HttpClient.GetAsJsonAsync<TrustlyPaymentResponseDto>(url);
            return new TrustlyPaymentResponse(paymentResponse, HttpClient);
        }
        public async Task<ITrustlyPaymentResponse> Create(TrustlyPaymentRequest paymentRequest, PaymentExpand paymentExpand)
        {
            var url = new Uri("/psp/trustly/payments", UriKind.Relative).GetUrlWithQueryString(paymentExpand);

            var requestDto = new TrustlyPaymentRequestDto(paymentRequest);

            var paymentResponse = await HttpClient.PostAsJsonAsync<TrustlyPaymentResponseDto>(url, requestDto);
            return new TrustlyPaymentResponse(paymentResponse, HttpClient);
        }
    }
}
