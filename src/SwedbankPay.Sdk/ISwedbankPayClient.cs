using SwedbankPay.Sdk.Consumers;
using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk
{
    public interface ISwedbankPayClient
    {
        //IPaymentsResource Payment { get; }
        IConsumersResource Consumers { get; }
        IPaymentOrderResource PaymentOrder { get; }
    }
}