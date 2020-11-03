namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class PaymentAbortRequestObject
    {
        public PaymentAbortRequestObject()
        {
            Operation = "Abort";
            AbortReason = "CancelledByConsumer";
        }


        public string AbortReason { get; set; }
        public string Operation { get; set; }
    }
}