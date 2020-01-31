namespace SwedbankPay.Sdk.PaymentOrders
{
    public class AbortRequest
    {
        public PaymentOrderAbortRequestObject PaymentOrder { get; } = new PaymentOrderAbortRequestObject();
    }
}