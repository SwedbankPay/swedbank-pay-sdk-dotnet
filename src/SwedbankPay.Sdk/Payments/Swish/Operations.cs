using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments.Swish
{
    public class Operations : Dictionary<LinkRelation, HttpOperation>
    {
        public Func<Task<PaymentResponse>> Abort { get; internal set; }
        public Func<ReversalRequest, Task<ReversalResponse>> CreateReversal { get; internal set; }
        public Func<SaleRequest, Task<SaleResponse>> CreateSale { get; internal set; }
        public HttpOperation this[LinkRelation rel] => ContainsKey(rel) ? base[rel] : null;
        public HttpOperation PaidPayment { get; internal set; }
        public HttpOperation RedirectSale { get; internal set; }
        public HttpOperation ViewSales { get; internal set; }
    }
}