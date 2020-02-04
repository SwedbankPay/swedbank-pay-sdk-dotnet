using SwedbankPay.Sdk.Consumers;
using SwedbankPay.Sdk.PaymentOrders;
using SwedbankPay.Sdk.Payments;

namespace SwedbankPay.Sdk
{
    public interface ISwedbankPayClient: IPaymentOrdersClient, IConsumersClient, IPaymentsClient
    {
    }
}
