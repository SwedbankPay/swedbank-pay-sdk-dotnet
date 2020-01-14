namespace SwedbankPay.Sdk.PaymentOrders
{
    public class AbortRequest
    {
        public PaymentOrderAbortRequestObject PaymentOrder { get; } = new PaymentOrderAbortRequestObject();


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
}