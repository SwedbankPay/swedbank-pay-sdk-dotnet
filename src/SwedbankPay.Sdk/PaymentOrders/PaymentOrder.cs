#region License

// --------------------------------------------------
// Copyright © Swedbank Pay. All Rights Reserved.
// 
// This software is proprietary information of Swedbank Pay.
// USE IS SUBJECT TO LICENSE TERMS.
// --------------------------------------------------

#endregion

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
        private PaymentOrder(PaymentOrderResponseContainer paymentOrderResponseContainer, SwedbankPayHttpClient client, SwedbankPayOptions swedbankPayOptions)
        {
            PaymentOrderResponse = paymentOrderResponseContainer.PaymentOrder;
            var operations = new Operations();
            
            foreach (var httpOperation in paymentOrderResponseContainer.Operations)
            {
                operations.Add(httpOperation.Rel, httpOperation);

                switch (httpOperation.Rel.Value)
                {
                    case PaymentOrderResourceOperations.CreatePaymentOrderCapture:
                        operations.Capture = new ExecuteRequestWrapper<TransactionRequestContainer, CaptureTransactionResponseContainer>(httpOperation.Request, client, m => new CouldNotPostTransactionException(httpOperation.Href, m));
                        break;
                    case PaymentOrderResourceOperations.CreatePaymentOrderCancel:
                        operations.Cancel = new ExecuteRequestWrapper<TransactionRequestContainer, CancellationTransactionResponseContainer>(httpOperation.Request, client, m => new CouldNotPostTransactionException(httpOperation.Href, m));
                        break;
                    case PaymentOrderResourceOperations.CreatePaymentOrderReversal:
                        operations.Reversal = new ExecuteRequestWrapper<TransactionRequestContainer, ReversalTransactionResponseContainer>(httpOperation.Request, client, m => new CouldNotPostTransactionException(httpOperation.Href, m));
                        break;
                    case PaymentOrderResourceOperations.UpdatePaymentOrderUpdateOrder:
                        operations.Update = new ExecuteRequestWrapper<PaymentOrderRequestContainer, PaymentOrderResponseContainer>(httpOperation.Request, client, m => new CouldNotUpdatePaymentOrderException(httpOperation.Href, m));
                        break;
                    case PaymentOrderResourceOperations.UpdatePaymentOrderAbort:
                        operations.Abort = new ExecuteWrapper<PaymentOrderResponseContainer>(httpOperation.Request, client, m => new CouldNotPostTransactionException(httpOperation.Href, m), new PaymentAbortRequestContainer());
                        break;
                    case "view-paymentorder":
                        operations.View = httpOperation;
                        break;
                }
                Operations = operations;
            }

            SwedbankPayOptions = swedbankPayOptions;

        }
        public Operations Operations { get; }
        public PaymentOrderResponse PaymentOrderResponse { get; }
        internal SwedbankPayOptions SwedbankPayOptions { get; }

        internal static async Task<PaymentOrder> Create(PaymentOrderRequest paymentOrderRequest, SwedbankPayHttpClient client, SwedbankPayOptions swedbankPayOptions, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None)
        {
            var url = $"/psp/paymentorders{GetExpandQueryString(paymentOrderExpand)}";
            paymentOrderRequest.SetRequiredMerchantInfo(swedbankPayOptions); //TODO set this here, elsewhere or set by user?
            
            var payload = new PaymentOrderRequestContainer(paymentOrderRequest);
            paymentOrderRequest.Operation = Operation.Purchase;

            Exception OnError(ProblemsContainer m) => new CouldNotPlacePaymentOrderException(payload, m);
            var paymentOrderResponseContainer = await client.HttpRequest<PaymentOrderResponseContainer>(HttpMethod.Post, url, OnError, payload);
            
            return new PaymentOrder(paymentOrderResponseContainer, client, swedbankPayOptions);
        }

        internal static async Task<PaymentOrder> Get(string id, SwedbankPayHttpClient client, SwedbankPayOptions swedbankPayOptions, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new CouldNotFindPaymentException(id);
            }

            var url = $"{id}{GetExpandQueryString(paymentOrderExpand)}";

            Exception OnError(ProblemsContainer m) => new CouldNotFindPaymentException(id, m);
            var paymentOrderResponseContainer = await client.HttpGet<PaymentOrderResponseContainer>(url, OnError);

            return new PaymentOrder(paymentOrderResponseContainer, client, swedbankPayOptions);
        }

        internal static string GetExpandQueryString<T>(T expandParameter) where T : Enum
        {
            var intValue = Convert.ToInt64(expandParameter);
            if (intValue == 0)
            {
                return string.Empty;
            }

            var s = new List<string>();
            foreach (var enumValue in Enum.GetValues(typeof(T)))
            {
                var name = Enum.GetName(typeof(T), enumValue);
                if (expandParameter.HasFlag((T)enumValue) && name != "None" && name != "All")
                {
                    s.Add(name.ToLower());
                }
            }

            var queryString = string.Join(",", s);
            return $"?$expand={queryString}";
        }

    }
}