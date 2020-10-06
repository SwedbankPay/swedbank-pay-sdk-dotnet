using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments
{
    public interface ISwishPaymentOperations
    {
        System.Func<PaymentAbortRequest, Task<SwishPaymentResponse>> Abort { get; }
        HttpOperation PaidPayment { get; }
        HttpOperation RedirectSale { get; }
        System.Func<SwishPaymentReversalRequest, Task<ReversalResponse>> Reverse { get; }
        System.Func<SwishPaymentSaleRequest, Task<SwishPaymentSaleResponse>> Sale { get; }
        HttpOperation ViewSales { get; }
    }
}