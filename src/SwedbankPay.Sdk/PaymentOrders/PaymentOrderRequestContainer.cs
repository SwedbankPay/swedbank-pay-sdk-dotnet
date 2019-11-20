namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderRequestContainer
    {
        public PaymentOrderRequestContainer(PaymentOrderRequest paymentOrder)
        {
            PaymentOrder = paymentOrder;
        }


        public PaymentOrderRequest PaymentOrder { get; }
    }
}
