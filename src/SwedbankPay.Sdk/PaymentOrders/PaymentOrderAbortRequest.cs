namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderAbortRequest
    {
        public PaymentOrderAbortRequestData PaymentOrder { get; } = new PaymentOrderAbortRequestData();
    }
}