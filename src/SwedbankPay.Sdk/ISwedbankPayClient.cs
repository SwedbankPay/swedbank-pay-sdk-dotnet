namespace SwedbankPay.Sdk
{
    using SwedbankPay.Sdk.Consumers;
    using SwedbankPay.Sdk.PaymentOrders;
    using SwedbankPay.Sdk.Payments;

    public interface ISwedbankPayClient
    {
        IPaymentOrdersResource PaymentOrders { get; }
        IPaymentsResource Payment { get; }
        IConsumersResource Consumers { get; }
    }
}
