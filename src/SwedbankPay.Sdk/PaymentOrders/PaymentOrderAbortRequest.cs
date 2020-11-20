namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderAbortRequest
    {
        public PaymentOrderAbortRequestDetails PaymentOrder { get; set; } = new PaymentOrderAbortRequestDetails();
    }
}