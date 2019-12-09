namespace SwedbankPay.Sdk.Payments
{
    public class PaymentAbortRequest
    {
        public PaymentAbortRequest()
        {
            Operation = "Abort";
            AbortReason = "CancelledByConsumer";
        }
        public string Operation { get; }
        public string AbortReason { get; }
    }
}