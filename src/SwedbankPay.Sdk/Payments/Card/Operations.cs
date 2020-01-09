using SwedbankPay.Sdk.PaymentOrders;

using System.Collections.Generic;

using SwedbankPay.Sdk.Transactions;

namespace SwedbankPay.Sdk.Payments.Card
{
    public class Operations : Dictionary<LinkRelation, HttpOperation>
    {
        public HttpOperation this[LinkRelation rel] => ContainsKey(rel) ? base[rel] : null;
        
        
        public HttpOperation Update { get; internal set; }
        public HttpOperation RedirectAuthorization { get; internal set; }
        public HttpOperation ViewAuthorization { get; internal set; }
        public HttpOperation DirectAuthorization { get; internal set; }
        public ExecuteRequestWrapper<TransactionRequestContainer<TransactionRequest>, CaptureTransactionResponseContainer> Capture { get; internal set; }
        public HttpOperation Cancel { get; internal set; }
        public ExecuteRequestWrapper<TransactionRequestContainer<ReversalTransactionRequest>, ReversalTransactionResponseContainer> Reversal { get; internal set; }
        public HttpOperation RedirectVerification { get; internal set; }
        public HttpOperation ViewVerification { get; internal set; }
        public HttpOperation DirectVerification { get; internal set; }
        public HttpOperation PaidPayment { get; internal set; }
    }
}
