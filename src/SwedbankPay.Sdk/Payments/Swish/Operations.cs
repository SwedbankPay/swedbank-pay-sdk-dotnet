using System.Collections.Generic;

using SwedbankPay.Sdk.Payments.Swish.Transactions;

namespace SwedbankPay.Sdk.Payments.Swish
{
    public class Operations : Dictionary<LinkRelation, HttpOperation>
    {
        public HttpOperation this[LinkRelation rel] => ContainsKey(rel) ? base[rel] : null;
        public ExecuteWrapper<PaymentResponseContainer<PaymentResponse>> Abort { get; internal set; }
        public ExecuteRequestWrapper<TransactionRequestContainer<SaleTransactionRequest>, SaleResponseContainer> CreateSale { get; internal set; }
        public ExecuteRequestWrapper<TransactionRequestContainer<ReversalTransactionRequest>, ReversalResponseContainer> CreateReversal { get; internal set; }
        public HttpOperation RedirectSale { get; internal set; }
        public HttpOperation ViewSales { get; internal set; }
        public HttpOperation PaidPayment { get; internal set; }
    }
}
