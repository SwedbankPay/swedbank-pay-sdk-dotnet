using System;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments.SwishPayments
{
    public class SwishPaymentOperations : OperationsBase
    {
        public Func<Task<SwishPaymentPaymentResponse>> Abort { get; internal set; }
        public Func<SwishPaymentReversalRequest, Task<ReversalResponse>> Reverse { get; internal set; }
        public Func<SwishPaymentSaleRequest, Task<SwishPaymentSaleResponse>> Sale { get; internal set; }
        public HttpOperation PaidPayment { get; internal set; }
        public HttpOperation RedirectSale { get; internal set; }
        public HttpOperation ViewSales { get; internal set; }
    }
}