using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using SwedbankPay.Sdk.Exceptions;
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
                                httpOperation.Request, client, (httpResponseMessage, problemsContainer) => new CouldNotPostTransactionException(httpResponseMessage, httpOperation.Href, problemsContainer));
                        break;
                    case PaymentOrderResourceOperations.CreatePaymentOrderCancel:
                        operations.Cancel =
                            new ExecuteRequestWrapper<TransactionRequestContainer, CancellationTransactionResponseContainer>(
                                httpOperation.Request, client, (httpResponseMessage, problemsContainer) => new CouldNotPostTransactionException(httpResponseMessage, httpOperation.Href, problemsContainer));
                        break;
                    case PaymentOrderResourceOperations.CreatePaymentOrderReversal:
                        operations.Reversal =
                            new ExecuteRequestWrapper<TransactionRequestContainer, ReversalTransactionResponseContainer>(
                                httpOperation.Request, client, (httpResponseMessage, problemsContainer) => new CouldNotPostTransactionException(httpResponseMessage, httpOperation.Href, problemsContainer));
                        break;
                    case PaymentOrderResourceOperations.UpdatePaymentOrderUpdateOrder: 
                        operations.Update = new ExecuteRequestWrapper<PaymentOrderUpdateRequestContainer, PaymentOrderResponseContainer>(
                            httpOperation.Request, client, (httpResponseMessage, problemsContainer) => new CouldNotUpdatePaymentOrderException(httpResponseMessage, httpOperation.Href, problemsContainer));
                        break;
                    case PaymentOrderResourceOperations.UpdatePaymentOrderAbort:
                        operations.Abort = new ExecuteWrapper<PaymentOrderResponseContainer>(
                            httpOperation.Request, client, (httpResponseMessage, problemsContainer) => new CouldNotPostTransactionException(httpResponseMessage, httpOperation.Href, problemsContainer),
                            new PaymentAbortRequestContainer());
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
                                                        SwedbankPayHttpClient client, string paymentOrderExpand)
        {
            var url = $"/psp/paymentorders{paymentOrderExpand}";
            
            var payload = new PaymentOrderRequestContainer(paymentOrderRequest);

            Exception OnError(HttpResponseMessage httpResponseMessage, ProblemsContainer problemsContainer)
            {
                return new CouldNotPlacePaymentOrderException(httpResponseMessage, payload, problemsContainer);
            }

            var paymentOrderResponseContainer =
                await client.SendHttpRequestAndProcessHttpResponse<PaymentOrderResponseContainer>(HttpMethod.Post, url, OnError, payload);

            return new PaymentOrder(paymentOrderResponseContainer, client);
        }


        /// <summary>
        /// Gets the payment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="client"></param>
        /// <param name="paymentOrderExpand"></param>
        /// <exception cref="CouldNotFindPaymentException"></exception>
        /// <exception cref="SdkException"></exception>
        /// <returns></returns>
        internal static async Task<PaymentOrder> Get(string id, SwedbankPayHttpClient client, string paymentOrderExpand)
        {
            var url = $"{id}{paymentOrderExpand}";

            Exception OnError(HttpResponseMessage httpResponseMessage, ProblemsContainer problemsContainer)
            {
                return new CouldNotFindPaymentException(httpResponseMessage, id, problemsContainer);
            }

            var paymentOrderResponseContainer = await client.HttpGet<PaymentOrderResponseContainer>(url, OnError);

            return new PaymentOrder(paymentOrderResponseContainer, client);
        }
    }
}