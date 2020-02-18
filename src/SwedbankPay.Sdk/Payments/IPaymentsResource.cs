using SwedbankPay.Sdk.Payments.CardPayments;
using SwedbankPay.Sdk.Payments.SwishPayments;
using SwedbankPay.Sdk.Payments.MobilePayPayments;

namespace SwedbankPay.Sdk.Payments
{
    public interface IPaymentsResource
    {
        ICardPaymentsResource CardPayments { get; }
        ISwishPaymentsResource SwishPayments { get; }
        IMobilePayPaymentsResource MobilePayPayments { get; }
    }
}