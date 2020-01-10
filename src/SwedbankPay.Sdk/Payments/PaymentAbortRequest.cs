namespace SwedbankPay.Sdk.Payments
{
    public class PaymentAbortRequest
    {
        public PaymentAbortRequestObject Payment { get; } = new PaymentAbortRequestObject();


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
}