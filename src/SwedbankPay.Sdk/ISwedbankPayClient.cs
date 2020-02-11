using SwedbankPay.Sdk.Consumers;
using SwedbankPay.Sdk.PaymentOrders;
using SwedbankPay.Sdk.Payments;

namespace SwedbankPay.Sdk
{
    public interface ISwedbankPayClient
    {
        public IPaymentOrdersResource PaymentOrders { get; }
        public IConsumersResource Consumers { get; }
        public IPaymentsResource Payments { get; }
    }
}
