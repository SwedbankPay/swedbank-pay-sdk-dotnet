namespace SwedbankPay.Sdk.PaymentOrders
{
    public interface IPaymentOrderResponse
    {
        IPaymentOrderOperations Operations { get; }
        IPaymentOrder PaymentOrder { get; }
    }
}