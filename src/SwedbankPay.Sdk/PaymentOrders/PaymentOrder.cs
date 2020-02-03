using System;
using System.Net.Http;
using System.Threading.Tasks;
using SwedbankPay.Sdk.Extensions;
using SwedbankPay.Sdk.Payments;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrder
    {
        private PaymentOrder(PaymentOrderResponse paymentOrderResponse,
                             HttpClient client)
        {
            PaymentOrderResponse = paymentOrderResponse.PaymentOrderResponseObject;
            var operations = new Operations();

            
            foreach (var httpOperation in paymentOrderResponse.Operations)
            {
                operations.Add(httpOperation.Rel, httpOperation);

                switch (httpOperation.Rel.Value)
                {
                    case PaymentOrderResourceOperations.CreatePaymentOrderCapture:
                        operations.Capture = async payload => await client.PostAsJsonAsync<CaptureResponse>(httpOperation.Href, payload);
                        break;
                    case PaymentOrderResourceOperations.CreatePaymentOrderCancel:
                        operations.Cancel = async payload => await client.PostAsJsonAsync<CancellationResponse>(httpOperation.Href, payload);
                        break;
                    case PaymentOrderResourceOperations.CreatePaymentOrderReversal:
                        operations.Reversal = async payload => await client.PostAsJsonAsync<ReversalResponse>(httpOperation.Href, payload);
                        break;
                    case PaymentOrderResourceOperations.UpdatePaymentOrderUpdateOrder:
                        operations.Update = async payload => await client.PatchAsJsonAsync<PaymentOrderResponse>(httpOperation.Href, payload);
                        break;
                    case PaymentOrderResourceOperations.UpdatePaymentOrderAbort:
                        operations.Abort = async () => await client.PatchAsJsonAsync<PaymentOrderResponse>(httpOperation.Href, new AbortRequest());
                        break;
                    case PaymentOrderResourceOperations.ViewPaymentOrder:
                        operations.View = httpOperation;
                        break;
                }

                Operations = operations;
            }
        }


        public Operations Operations { get; }
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