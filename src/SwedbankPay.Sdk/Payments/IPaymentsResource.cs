using SwedbankPay.Sdk.Payments.CardPayments;
using SwedbankPay.Sdk.Payments.SwishPayments;

namespace SwedbankPay.Sdk.Payments
{
    public interface IPaymentsResource
    {
        ICardPaymentsResource CardPayments { get; }
        ISwishPaymentsResource SwishPayments { get; }
    }
}