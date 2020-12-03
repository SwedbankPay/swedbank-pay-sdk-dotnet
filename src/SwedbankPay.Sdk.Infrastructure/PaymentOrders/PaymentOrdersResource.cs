using SwedbankPay.Sdk.Extensions;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrdersResource : ResourceBase, IPaymentOrdersResource
    {
        public PaymentOrdersResource(HttpClient httpClient) : base(httpClient)
        {
        }

        /// <summary>
        ///     Get payment order by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="paymentOrderExpand"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="HttpRequestException"></exception>
        /// <exception cref="HttpResponseException"></exception>
        public async Task<IPaymentOrderResponse> Get(Uri id, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id), $"{id} cannot be null");
            }

            Uri url = id.GetUrlWithQueryString(paymentOrderExpand);

            var paymentOrderResponseContainer = await HttpClient.GetAsJsonAsync<PaymentOrderResponseDto>(url);

            return new PaymentOrderResponse(paymentOrderResponseContainer, HttpClient);
        }

        /// <summary>
        ///     Create a payment order
        /// </summary>
        /// <param name="paymentOrderRequest"></param>
        /// <param name="paymentOrderExpand"></param>
        /// <returns></returns>
        public async Task<IPaymentOrderResponse> Create(PaymentOrderRequest paymentOrderRequest,
                                               PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None)
        {
            var url = new Uri("/psp/paymentorders", UriKind.Relative).GetUrlWithQueryString(paymentOrderExpand);

            var paymentOrderResponseContainer = await HttpClient.PostAsJsonAsync<PaymentOrderResponseDto>(url, paymentOrderRequest);

            return new PaymentOrderResponse(paymentOrderResponseContainer, HttpClient);
        }
    }
}
