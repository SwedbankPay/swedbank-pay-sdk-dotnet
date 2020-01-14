using SwedbankPay.Sdk.Consumers;
using SwedbankPay.Sdk.PaymentOrders;
using SwedbankPay.Sdk.Payments;

namespace SwedbankPay.Sdk
{
    public interface ISwedbankPayClient
    {
        IConsumersResource Consumers { get; }
        IPaymentsResource Payment { get; }
        IPaymentOrderResource PaymentOrder { get; }
    }
}