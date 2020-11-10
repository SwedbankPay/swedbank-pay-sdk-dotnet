namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderAbortRequestData
    {
        public PaymentOrderAbortRequestData()
        {
            Operation = "Abort";
            AbortReason = "CancelledByConsumer";
        }


        public string AbortReason { get; }
        public string Operation { get; }
    }
}