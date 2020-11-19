namespace SwedbankPay.Sdk.PaymentOrders
{
    public interface IPaymentOrderResponse
    {
        /// <summary>
        /// Currently available operations of this payment order.
        /// </summary>
        IPaymentOrderOperations Operations { get; }

        /// <summary>
        /// The current payment order.
        /// </summary>
        IPaymentOrder PaymentOrder { get; }
    }
}