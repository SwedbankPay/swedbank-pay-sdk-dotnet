using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments.TrustlyPayments
{
    public interface ITrustlyPaymentOperations : IDictionary<LinkRelation, HttpOperation>
    {
        System.Func<PaymentAbortRequest, Task<TrustlyPaymentResponse>> Abort { get; }
        System.Func<TrustlyPaymentCancelRequest, Task<CancellationResponse>> Cancel { get; }
        HttpOperation RedirectSale { get; }
        System.Func<TrustlyPaymentReversalRequest, Task<ReversalResponse>> Reverse { get; }
        HttpOperation ViewSale { get; }
    }
}