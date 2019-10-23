namespace SwedbankPay.Sdk
{
    using SwedbankPay.Sdk.Resources;

    public interface ISwedbankPayClient
    {
        IPaymentOrdersResource PaymentOrders { get; }
    }
}
