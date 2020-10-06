
namespace SwedbankPay.Sdk.PaymentOrders
{
    public interface IPaymentOrder
    {
        IPaymentOrderOperations Operations { get; }
        PaymentOrderResponseObject PaymentOrderResponse { get; }
    }
}