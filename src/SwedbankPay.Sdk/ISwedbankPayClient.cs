using SwedbankPay.Sdk.Consumers;
using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk
{
    public interface ISwedbankPayClient
    {
        IConsumersResource Consumers { get; }
        IPaymentOrderResource PaymentOrder { get; }
    }
}