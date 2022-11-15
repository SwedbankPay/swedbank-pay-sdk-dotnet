﻿#region License

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
    internal class PaymentOrderOperations : OperationsBase, IPaymentOrderOperations
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
                            var requestDto = new PaymentOrderCaptureRequestDto(payload);
                            var dto = await client.SendAsJsonAsync<CaptureResponseDto>(httpOperation.Method, httpOperation.Href, requestDto);
                            return new CaptureResponse(dto);
                        };
                        break;
                    case PaymentOrderResourceOperations.CreatePaymentOrderCancel:
                        Cancel = async payload =>
                        {
                            var requestDto = new PaymentOrderCancelRequestDto(payload);
                            var dto = await client.SendAsJsonAsync<CancelResponseDto>(httpOperation.Method, httpOperation.Href, requestDto);
                            return new CancellationResponse(dto.Payment, dto.Cancellation.Map());
                        };
                        break;
                    case PaymentOrderResourceOperations.CreatePaymentOrderReversal:
                        Reverse = async payload =>
                        {
                            var url = httpOperation.Href.GetUrlWithQueryString(PaymentExpand.All);
                            var requestDto = new PaymentOrderReversalRequestDto(payload);
                            var paymentOrderResponseContainer = await client.SendAsJsonAsync<ReversalResponseDto>(httpOperation.Method, url, requestDto);
                            return new ReversalResponse(paymentOrderResponseContainer.Payment, paymentOrderResponseContainer.Reversal.Map());
                        };
                        break;
                    case PaymentOrderResourceOperations.UpdatePaymentOrderUpdateOrder:
                        Update = async payload =>
                        {
                            var url = httpOperation.Href.GetUrlWithQueryString(PaymentExpand.All);
                            var requestDto = new PaymentOrderUpdateRequestDto(payload);
                            var paymentOrderResponseContainer = await client.SendAsJsonAsync<PaymentOrderResponseDto>(httpOperation.Method, url, requestDto);
                            return new PaymentOrderResponse(paymentOrderResponseContainer, client);
                        };
                        break;
                    case PaymentOrderResourceOperations.UpdatePaymentOrderAbort:
                        Abort = async payload =>
                        {
                            var url = httpOperation.Href.GetUrlWithQueryString(PaymentExpand.All);
                            var paymentOrderResponseContainer = await client.SendAsJsonAsync<PaymentOrderResponseDto>(httpOperation.Method, url, payload);
                            return new PaymentOrderResponse(paymentOrderResponseContainer, client);
                        };
                        break;
                    case PaymentOrderResourceOperations.ViewPaymentOrder:
                        View = httpOperation;
                        break;
                    case PaymentOrderResourceOperations.RedirectCheckout:
                        RedirectCheckout = httpOperation;
                        break;
                }
                Add(httpOperation.Rel, httpOperation);
            }
        }

        public Func<PaymentOrderAbortRequest, Task<IPaymentOrderResponse>> Abort { get; }
        public Func<PaymentOrderCancelRequest, Task<CancellationResponse>> Cancel { get; }
        public Func<PaymentOrderCaptureRequest, Task<ICaptureResponse>> Capture { get; }
        public Func<PaymentOrderReversalRequest, Task<IReversalResponse>> Reverse { get; }
        public Func<PaymentOrderUpdateRequest, Task<IPaymentOrderResponse>> Update { get; }
        public HttpOperation View { get; }
        public HttpOperation RedirectCheckout { get; }
    }
}