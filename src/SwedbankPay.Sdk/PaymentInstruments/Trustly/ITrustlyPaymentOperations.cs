using SwedbankPay.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentInstruments.Trustly
{
    public interface ITrustlyPaymentOperations : IDictionary<LinkRelation, HttpOperation>
    {
        Func<PaymentAbortRequest, Task<ITrustlyPayment>> Abort { get; }
        Func<TrustlyPaymentCancelRequest, Task<CancellationResponse>> Cancel { get; }
        HttpOperation RedirectSale { get; }
        Func<TrustlyPaymentReversalRequest, Task<ReversalResponse>> Reverse { get; }
        HttpOperation ViewSale { get; }
    }
}