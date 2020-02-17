namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderAbortRequest
    {
        public PaymentOrderAbortRequestObject PaymentOrder { get; } = new PaymentOrderAbortRequestObject();
    }
}