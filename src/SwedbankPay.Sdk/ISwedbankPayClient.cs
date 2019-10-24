namespace SwedbankPay.Sdk
{
    using SwedbankPay.Sdk.PaymentOrders;
    
    public interface ISwedbankPayClient
    {
        IPaymentOrdersResource PaymentOrders { get; }
    }
}
