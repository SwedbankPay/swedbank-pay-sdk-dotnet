namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderAbortRequestObject
    {
        public PaymentOrderAbortRequestObject()
        {
            Operation = "Abort";
            AbortReason = "CancelledByConsumer";
        }


        public string AbortReason { get; }
        public string Operation { get; }
    }
}