using System;
using System.Threading.Tasks;

using SwedbankPay.Sdk.Payments;
using SwedbankPay.Sdk.Transactions;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrder
    {
        private PaymentOrder(PaymentOrderResponseContainer paymentOrderResponseContainer,
                             SwedbankPayHttpClient client)
        {
            PaymentOrderResponse = paymentOrderResponseContainer.PaymentOrder;
            var operations = new Operations();

            foreach (var httpOperation in paymentOrderResponseContainer.Operations)
            {
                operations.Add(httpOperation.Rel, httpOperation);

                switch (httpOperation.Rel.Value)
                {
                    case PaymentOrderResourceOperations.CreatePaymentOrderCapture:
                        operations.Capture =
                            new ExecuteRequestWrapper<TransactionRequestContainer, CaptureTransactionResponseContainer>(
                                httpOperation.Request, client);
                        break;
                    case PaymentOrderResourceOperations.CreatePaymentOrderCancel:
                        operations.Cancel =
                            new ExecuteRequestWrapper<TransactionRequestContainer, CancellationTransactionResponseContainer>(
                                httpOperation.Request, client);
                        break;
                    case PaymentOrderResourceOperations.CreatePaymentOrderReversal:
                        operations.Reversal =
                            new ExecuteRequestWrapper<TransactionRequestContainer, ReversalTransactionResponseContainer>(
                                httpOperation.Request, client);
                        break;
                    case PaymentOrderResourceOperations.UpdatePaymentOrderUpdateOrder:
                        operations.Update = new ExecuteRequestWrapper<PaymentOrderUpdateRequestContainer, PaymentOrderResponseContainer>(
                            httpOperation.Request, client);
                        break;
                    case PaymentOrderResourceOperations.UpdatePaymentOrderAbort:
                        operations.Abort = new ExecuteWrapper<PaymentOrderResponseContainer>(
                            httpOperation.Request, client, new PaymentAbortRequestContainer());
                        break;
                    case PaymentOrderResourceOperations.ViewPaymentOrder:
                        operations.View = httpOperation;
                        break;
                }

                Operations = operations;
            }
        }


        public Operations Operations { get; }
        public PaymentOrderResponse PaymentOrderResponse { get; }


        internal static async Task<PaymentOrder> Create(PaymentOrderRequest paymentOrderRequest,
                                                        SwedbankPayHttpClient client,
                                                        string paymentOrderExpand)
        {
            var url = new Uri($"/psp/paymentorders{paymentOrderExpand}", UriKind.Relative);

            var payload = new PaymentOrderRequestContainer(paymentOrderRequest);

            var paymentOrderResponseContainer =
                await client.HttpPost<PaymentOrderResponseContainer>(url, payload);

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
        /// <exception cref="SwedbankPay.Sdk.Exceptions.HttpResponseException"></exception>
        /// <returns></returns>
        internal static async Task<PaymentOrder> Get(Uri id, SwedbankPayHttpClient client, string paymentOrderExpand)
        {
            var url = !string.IsNullOrWhiteSpace(paymentOrderExpand)
                ? new Uri(id.OriginalString + paymentOrderExpand, UriKind.RelativeOrAbsolute)
                : id;
            var paymentOrderResponseContainer = await client.HttpGet<PaymentOrderResponseContainer>(url);

            return new PaymentOrder(paymentOrderResponseContainer, client);
        }
    }
}