namespace SwedbankPay.Sdk
{
    using SwedbankPay.Sdk.Consumers;
    using SwedbankPay.Sdk.PaymentOrders;
    using SwedbankPay.Sdk.Payments;

    public interface ISwedbankPayClient
    {
        IPaymentOrderResource PaymentOrder { get; }
        //IPaymentsResource Payment { get; }
        IConsumersResource Consumers { get; }
    }
}
