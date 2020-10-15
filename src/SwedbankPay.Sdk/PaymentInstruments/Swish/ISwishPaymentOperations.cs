using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments.SwishPayments
{
    public interface ISwishPaymentOperations : IDictionary<LinkRelation, HttpOperation>
    {
        System.Func<PaymentAbortRequest, Task<ISwishPaymentResponse>> Abort { get; }
        HttpOperation PaidPayment { get; }
        HttpOperation RedirectSale { get; }
        System.Func<SwishPaymentReversalRequest, Task<ReversalResponse>> Reverse { get; }
        System.Func<SwishPaymentSaleRequest, Task<SwishPaymentSaleResponse>> Sale { get; }
        HttpOperation ViewSales { get; }
    }
}