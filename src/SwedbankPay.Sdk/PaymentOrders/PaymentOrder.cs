using System;
using System.Threading.Tasks;

using SwedbankPay.Sdk.Payments;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrder
    {
        private PaymentOrder(PaymentOrderResponse paymentOrderResponse,
                             SwedbankPayHttpClient client)
        {
            PaymentOrderResponse = paymentOrderResponse.PaymentOrderResponseObject;
            var operations = new Operations();

            
            foreach (var httpOperation in paymentOrderResponse.Operations)
            {
                operations.Add(httpOperation.Rel, httpOperation);

                switch (httpOperation.Rel.Value)
                {
                    case PaymentOrderResourceOperations.CreatePaymentOrderCapture:
                        operations.Capture = async payload => await client.SendHttpRequestAndProcessHttpResponse<CaptureResponse>(httpOperation.Request.AttachPayload(payload));
                        break;
                    case PaymentOrderResourceOperations.CreatePaymentOrderCancel:
                        operations.Cancel = async payload => await client.SendHttpRequestAndProcessHttpResponse<CancellationResponse>(httpOperation.Request.AttachPayload(payload));
                        break;
                    case PaymentOrderResourceOperations.CreatePaymentOrderReversal:
                        operations.Reversal = async payload => await client.SendHttpRequestAndProcessHttpResponse<ReversalResponse>(httpOperation.Request.AttachPayload(payload));
                        break;
                    case PaymentOrderResourceOperations.UpdatePaymentOrderUpdateOrder:
                        operations.Update = async payload => await client.SendHttpRequestAndProcessHttpResponse<PaymentOrderResponse>(httpOperation.Request.AttachPayload(payload));
                        break;
                    case PaymentOrderResourceOperations.UpdatePaymentOrderAbort:
                        operations.Abort = async () => await client.SendHttpRequestAndProcessHttpResponse<PaymentOrderResponse>(httpOperation.Request.AttachPayload(new AbortRequest()));
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
                                                        SwedbankPayHttpClient client,
                                                        string paymentOrderExpand)
        {
            var url = new Uri($"/psp/paymentorders{paymentOrderExpand}", UriKind.Relative);
            
            var paymentOrderResponseContainer = await client.HttpPost<PaymentOrderResponse>(url, paymentOrderRequest);

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
        internal static async Task<PaymentOrder> Get(Uri id, SwedbankPayHttpClient client, string paymentOrderExpand)
        {
            var url = !string.IsNullOrWhiteSpace(paymentOrderExpand)
                ? new Uri(id.OriginalString + paymentOrderExpand, UriKind.RelativeOrAbsolute)
                : id;
            var paymentOrderResponseContainer = await client.HttpGet<PaymentOrderResponse>(url);

            return new PaymentOrder(paymentOrderResponseContainer, client);
        }
    }
}