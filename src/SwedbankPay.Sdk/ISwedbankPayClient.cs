using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk;

public interface ISwedbankPayClient
{
    /// <summary>
    /// Resource to create and get payment orders.
    /// </summary>
    IPaymentOrdersResource PaymentOrders { get; }
}