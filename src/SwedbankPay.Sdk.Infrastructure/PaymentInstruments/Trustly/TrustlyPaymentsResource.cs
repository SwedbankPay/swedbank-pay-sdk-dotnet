using SwedbankPay.Sdk.Extensions;
using SwedbankPay.Sdk.Payments.TrustlyPayments;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments
{
    public class TrustlyPaymentsResource : ResourceBase, ITrustlyResource
    {
        public TrustlyPaymentsResource(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<ITrustlyPayment> Create(TrustlyPaymentRequest paymentRequest, PaymentExpand paymentExpand)
        {
            var url = new Uri($"/psp/trustly/payments{paymentExpand}", UriKind.Relative);

            var paymentResponse = await HttpClient.PostAsJsonAsync<TrustlyPaymentResponseDto>(url, paymentRequest);
            return new TrustlyPayment(paymentResponse);
        }

        public async Task<ITrustlyPayment> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            Uri url = id.GetUrlWithQueryString(paymentExpand);

            var paymentResponse = await HttpClient.GetAsJsonAsync<TrustlyPaymentResponseDto>(url);
            return new TrustlyPayment(paymentResponse);
        }
    }
}
