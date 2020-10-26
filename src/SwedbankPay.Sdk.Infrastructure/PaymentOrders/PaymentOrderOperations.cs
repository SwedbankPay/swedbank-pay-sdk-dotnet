#region License

// --------------------------------------------------
// Copyright © Swedbank Pay. All Rights Reserved.
// 
// This software is proprietary information of Swedbank Pay.
// USE IS SUBJECT TO LICENSE TERMS.
// --------------------------------------------------

#endregion

using SwedbankPay.Sdk.Common;
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
                        Capture = async payload => await client.SendAsJsonAsync<CaptureResponse>(httpOperation.Method, httpOperation.Href, payload);
                        break;
                    case PaymentOrderResourceOperations.CreatePaymentOrderCancel:
                        Cancel = async payload => await client.SendAsJsonAsync<CancellationResponse>(httpOperation.Method, httpOperation.Href, payload);
                        break;
                    case PaymentOrderResourceOperations.CreatePaymentOrderReversal:
                        Reverse = async payload => await client.SendAsJsonAsync<ReversalResponse>(httpOperation.Method, httpOperation.Href, payload);
                        break;
                    case PaymentOrderResourceOperations.UpdatePaymentOrderUpdateOrder:
                        Update = async payload => await client.SendAsJsonAsync<PaymentOrderResponse>(httpOperation.Method, httpOperation.Href, payload);
                        break;
                    case PaymentOrderResourceOperations.UpdatePaymentOrderAbort:
                        Abort = async () => await client.SendAsJsonAsync<PaymentOrderResponse>(httpOperation.Method, httpOperation.Href, new PaymentOrderAbortRequest());
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
        public Func<PaymentOrderReversalRequest, Task<ReversalResponse>> Reverse { get; }
        public Func<PaymentOrderUpdateRequest, Task<IPaymentOrderResponse>> Update { get; }
        public HttpOperation View { get; internal set; }
    }
}