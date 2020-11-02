#region License

// --------------------------------------------------
// Copyright © Swedbank Pay. All Rights Reserved.
// 
// This software is proprietary information of Swedbank Pay.
// USE IS SUBJECT TO LICENSE TERMS.
// --------------------------------------------------

#endregion

using SwedbankPay.Sdk.Extensions;
using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderOperations : OperationsBase, IPaymentOrderOperations
    {
        public PaymentOrderOperations(IOperationList operations, HttpClient client)
        {
            foreach (var httpOperation in operations)
            {
                switch (httpOperation.Rel.Value)
                {
                    case PaymentOrderResourceOperations.CreatePaymentOrderCapture:
                        Capture = async payload =>
                        {
                            return await client.SendAsJsonAsync<CaptureResponse>(httpOperation.Method, httpOperation.Href, payload);
                        };
                        break;
                    case PaymentOrderResourceOperations.CreatePaymentOrderCancel:
                        Cancel = async payload =>
                        {
                            return await client.SendAsJsonAsync<CancellationResponse>(httpOperation.Method, httpOperation.Href, payload);
                        };
                        break;
                    case PaymentOrderResourceOperations.CreatePaymentOrderReversal:
                        Reverse = async payload =>
                        {
                            var url = httpOperation.Href.GetUrlWithQueryString(PaymentExpand.All);
                            var paymentOrderResponseContainer = await client.SendAsJsonAsync<ReversalResponseDto>(httpOperation.Method, url, payload);
                            return new ReversalResponse(paymentOrderResponseContainer.Payment, paymentOrderResponseContainer.Reversal.Map());
                        };
                        break;
                    case PaymentOrderResourceOperations.UpdatePaymentOrderUpdateOrder:
                        Update = async payload =>
                        {
                            var url = httpOperation.Href.GetUrlWithQueryString(PaymentExpand.All);
                            var paymentOrderResponseContainer = await client.SendAsJsonAsync<PaymentOrderResponseDto>(httpOperation.Method, url, payload);
                            return new PaymentOrderResponse(paymentOrderResponseContainer, client);
                        };
                        break;
                    case PaymentOrderResourceOperations.UpdatePaymentOrderAbort:
                        Abort = async () =>
                        {
                            var url = httpOperation.Href.GetUrlWithQueryString(PaymentExpand.All);
                            var paymentOrderResponseContainer = await client.SendAsJsonAsync<PaymentOrderResponseDto>(httpOperation.Method, url, new PaymentOrderAbortRequest());
                            return new PaymentOrderResponse(paymentOrderResponseContainer, client);
                        };
                        break;
                    case PaymentOrderResourceOperations.ViewPaymentOrder:
                        View = httpOperation;
                        break;
                }
                this.Add(httpOperation.Rel, httpOperation);
            }
        }

        public Func<Task<IPaymentOrderResponse>> Abort { get; }
        public Func<PaymentOrderCancelRequest, Task<CancellationResponse>> Cancel { get; }
        public Func<PaymentOrderCaptureRequest, Task<CaptureResponse>> Capture { get; }
        public Func<PaymentOrderReversalRequest, Task<IReversalResponse>> Reverse { get; }
        public Func<PaymentOrderUpdateRequest, Task<IPaymentOrderResponse>> Update { get; }
        public HttpOperation View { get; internal set; }
    }
}