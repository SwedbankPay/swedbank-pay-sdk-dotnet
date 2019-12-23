using SwedbankPay.Sdk.PaymentOrders;
using SwedbankPay.Sdk.Transactions;

using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments
{
    public class Operations : Dictionary<LinkRelation, HttpOperation>
    {
        public HttpOperation this[LinkRelation rel] => ContainsKey(rel) ? base[rel] : null;
        public ExecuteRequestWrapper<TransactionRequestContainer, CancellationTransactionResponseContainer> Cancel { get; internal set; }
        public ExecuteRequestWrapper<TransactionRequestContainer, CaptureTransactionResponseContainer> Capture { get; internal set; }
        public ExecuteRequestWrapper<TransactionRequestContainer, ReversalTransactionResponseContainer> Reversal { get; internal set; }
        public ExecuteRequestWrapper<PaymentOrderUpdateRequestContainer, PaymentOrderResponseContainer> Update { get; internal set; }
        public HttpOperation ViewAuthorization { get; internal set; }
        public HttpOperation RedirectAuthorization { get; internal set; }
        public ExecuteRequestWrapper<TransactionRequestContainer, PaymentOrderResponseContainer> DirectAuthorization { get; internal set; }
        public HttpOperation RedirectVerification { get; internal set; }
        public HttpOperation ViewVerification { get; internal set; }
        public ExecuteRequestWrapper<TransactionRequestContainer, ReversalTransactionResponseContainer> DirectVerification { get; internal set; }
        public ExecuteRequestWrapper<TransactionRequestContainer, ReversalTransactionResponseContainer> PaidPayment { get; internal set; }
    }
}
