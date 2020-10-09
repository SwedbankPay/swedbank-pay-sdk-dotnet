namespace SwedbankPay.Sdk.Payments
{
    public class PaymentAbortRequestObject
    {
        public PaymentAbortRequestObject()
        {
            Operation = "Abort";
            AbortReason = "CancelledByConsumer";
        }


        public string AbortReason { get; }
        public string Operation { get; }
    }
}