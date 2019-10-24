namespace SwedbankPay.Sdk.Payments
{
    public class PaymentAbortRequest
    {
        public string Operation { get; set; } = "Abort";
        public string AbortReason { get; set; } = "CancelledByConsumer";
    }
}