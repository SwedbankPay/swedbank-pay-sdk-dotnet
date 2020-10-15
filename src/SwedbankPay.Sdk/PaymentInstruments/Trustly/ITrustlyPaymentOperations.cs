using SwedbankPay.Sdk.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentInstruments.Trustly
{
    public interface ITrustlyPaymentOperations : IDictionary<LinkRelation, HttpOperation>
    {
        System.Func<PaymentAbortRequest, Task<ITrustlyPayment>> Abort { get; }
        System.Func<TrustlyPaymentCancelRequest, Task<CancellationResponse>> Cancel { get; }
        HttpOperation RedirectSale { get; }
        System.Func<TrustlyPaymentReversalRequest, Task<ReversalResponse>> Reverse { get; }
        HttpOperation ViewSale { get; }
    }
}