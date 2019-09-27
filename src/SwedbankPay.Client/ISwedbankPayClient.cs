using SwedbankPay.Client.Resources;

namespace SwedbankPay.Client
{
    public interface ISwedbankPayClient
    {
        IPaymentOrdersResource PaymentOrders { get; }
    }
}
