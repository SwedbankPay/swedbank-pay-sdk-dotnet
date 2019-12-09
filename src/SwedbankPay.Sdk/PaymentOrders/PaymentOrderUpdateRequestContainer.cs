namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderUpdateRequestContainer
    {
        public PaymentOrderUpdateRequestContainer(PaymentOrderUpdateRequest paymentOrderUpdateRequest)
        {
            PaymentOrder = paymentOrderUpdateRequest;
        }
        public PaymentOrderUpdateRequest PaymentOrder { get; }
    }
}