namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class PaymentAbortRequestData
    {
        public PaymentAbortRequestData()
        {
            Operation = "Abort";
            AbortReason = "CancelledByConsumer";
        }


        public string AbortReason { get; set; }
        public string Operation { get; set; }
    }
}