namespace SwedbankPay.Sdk.Payments
{
    public class PaymentAbortRequest
    {
        public PaymentAbortRequest()
        {
            Operation = "Abort";
            AbortReason = "CancelledByConsumer";
        }


        public string AbortReason { get; }
        public string Operation { get; }
    }
}