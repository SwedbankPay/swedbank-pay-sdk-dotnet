using SwedbankPay.Sdk.Payments.CardPayments;
using SwedbankPay.Sdk.Payments.SwishPayments;

namespace SwedbankPay.Sdk.Payments
{
    public interface IPaymentsResource
    {
        public ICardPaymentsResource CardPayments { get; set; }
        public ISwishPaymentsResource SwishPayments { get; set; }
    }
}