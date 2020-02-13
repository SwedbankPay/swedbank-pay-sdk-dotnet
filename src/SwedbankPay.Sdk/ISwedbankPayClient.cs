using SwedbankPay.Sdk.Consumers;
using SwedbankPay.Sdk.PaymentOrders;
using SwedbankPay.Sdk.Payments;

namespace SwedbankPay.Sdk
{
    public interface ISwedbankPayClient
    {
        IPaymentOrdersResource PaymentOrders { get; }
        IConsumersResource Consumers { get; }
        IPaymentsResource Payments { get; }
    }
}
