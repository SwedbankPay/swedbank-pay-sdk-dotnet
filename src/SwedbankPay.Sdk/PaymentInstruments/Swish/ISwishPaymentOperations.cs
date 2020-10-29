using SwedbankPay.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public interface ISwishPaymentOperations : IDictionary<LinkRelation, HttpOperation>
    {
        Func<PaymentAbortRequest, Task<ISwishPaymentResponse>> Abort { get; }
        HttpOperation PaidPayment { get; }
        HttpOperation RedirectSale { get; }
        Func<SwishPaymentReversalRequest, Task<IReversalResponse>> Reverse { get; }
        Func<SwishPaymentSaleRequest, Task<SwishPaymentSaleResponse>> Sale { get; }
        HttpOperation ViewSales { get; }
    }
}