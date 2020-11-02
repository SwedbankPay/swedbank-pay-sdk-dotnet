using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentInstruments.Trustly
{
    public interface ITrustlyPaymentOperations : IDictionary<LinkRelation, HttpOperation>
    {
        Func<PaymentAbortRequest, Task<ITrustlyPayment>> Abort { get; }
        Func<TrustlyPaymentCancelRequest, Task<ICancellationResponse>> Cancel { get; }
        HttpOperation RedirectSale { get; }
        Func<TrustlyPaymentReversalRequest, Task<IReversalResponse>> Reverse { get; }
        HttpOperation ViewSale { get; }
    }
}