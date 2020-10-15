using SwedbankPay.Sdk.Consumers;
using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk
{
    public interface ISwedbankPayClient
    {
        IPaymentOrdersResource PaymentOrders { get; }
        IConsumersResource Consumers { get; }
        IPaymentsResource Payments { get; }
    }
}
