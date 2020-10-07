using System;
using System.Net.Http;
using System.Threading.Tasks;
using SwedbankPay.Sdk.Extensions;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrder : IPaymentOrder
    {
        private PaymentOrder(PaymentOrderResponse paymentOrderResponse,
                             HttpClient client)
        {
            PaymentOrderResponse = paymentOrderResponse.PaymentOrder;
            var operations = new PaymentOrderOperations(paymentOrderResponse.Operations, client);
            Operations = operations;
        }


        public IPaymentOrderOperations Operations { get; }
        public PaymentOrderResponseObject PaymentOrderResponse { get; }


        internal static async Task<PaymentOrder> Create(PaymentOrderRequest paymentOrderRequest,
                                                        HttpClient client,
                                                        string paymentOrderExpand)
        {
            var url = new Uri($"/psp/paymentorders{paymentOrderExpand}", UriKind.Relative);

            var paymentOrderResponseContainer = await client.PostAsJsonAsync<PaymentOrderResponse>(url, paymentOrderRequest);

            return new PaymentOrder(paymentOrderResponseContainer, client);
        }


        /// <summary>
        ///     Gets the payment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="client"></param>
        /// <param name="paymentOrderExpand"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="System.Net.Http.HttpRequestException"></exception>
        /// <exception cref="Exceptions.HttpResponseException"></exception>
        /// <returns></returns>
        internal static async Task<PaymentOrder> Get(Uri id, HttpClient client, string paymentOrderExpand)
        {
            var url = !string.IsNullOrWhiteSpace(paymentOrderExpand)
                ? new Uri(id.OriginalString + paymentOrderExpand, UriKind.RelativeOrAbsolute)
                : id;

            var paymentOrderResponseContainer = await client.GetAsJsonAsync<PaymentOrderResponse>(url);

            return new PaymentOrder(paymentOrderResponseContainer, client);
        }
    }
}