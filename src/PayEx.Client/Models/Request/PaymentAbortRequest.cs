namespace SwedbankPay.Client.Models.Request
{
    public class PaymentAbortRequest
    {
        public string Operation { get; set; } = "Abort";
        public string AbortReason { get; set; } = "CancelledByCustomer";
    }
}