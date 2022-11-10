﻿using SwedbankPay.Sdk.Extensions;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentInstruments.Trustly;

internal class TrustlyPaymentOperations : OperationsBase, ITrustlyPaymentOperations
{
    public TrustlyPaymentOperations(IOperationList operations, HttpClient client)
    {
        foreach (var httpOperation in operations)
        {
            switch (httpOperation.Rel.Value)
            {
                case PaymentResourceOperations.RedirectSale:
                    RedirectSale = httpOperation;
                    break;

                case PaymentResourceOperations.ViewSale:
                    ViewSale = httpOperation;
                    break;

                case PaymentResourceOperations.UpdatePaymentAbort:
                    Abort = async payload => {
                        var requestDto = new PaymentAbortRequestDto(payload);
                        var dto = await client.SendAsJsonAsync<TrustlyPaymentResonseDto>(httpOperation.Method, httpOperation.Href, requestDto);
                        return new TrustlyPayment(dto.Payment);
                    };
                    break;

                case PaymentResourceOperations.CreateReversal:
                    Reverse = async payload => {
                        var requestDto = new TrustlyPaymentReversalRequestDto(payload);
                        var dto= await client.SendAsJsonAsync<ReversalResponseDto>(httpOperation.Method, httpOperation.Href, requestDto);
                        return new ReversalResponse(dto.Payment, dto.Reversal.Map());
                    };
                    break;

                case PaymentResourceOperations.CreateCancellation:
                    Cancel = async payload => {
                        var requestDto = new TrustlyPaymentCancelRequestDto(payload);
                        var dto = await client.SendAsJsonAsync<CancellationResponseDto>(httpOperation.Method, httpOperation.Href, requestDto);
                        return new CancellationResponse(dto.Payment, dto.Cancellation.Map());
                    };
                    break;
            }
            Add(httpOperation.Rel, httpOperation);
        }
    }

    public HttpOperation RedirectSale { get; }
    public HttpOperation ViewSale { get; }
    public Func<PaymentAbortRequest, Task<ITrustlyPayment>> Abort { get; }
    public Func<TrustlyPaymentReversalRequest, Task<IReversalResponse>> Reverse { get; }
    public Func<TrustlyPaymentCancelRequest, Task<ICancellationResponse>> Cancel { get; }
}