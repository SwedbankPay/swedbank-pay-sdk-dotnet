namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderAbortRequestData
    {
        public PaymentOrderAbortRequestData()
        {
            AbortReason = "CancelledByConsumer";
        }

        /// <summary>
        /// The reason why the current payment is being aborted.
        /// </summary>
        public string AbortReason { get; set; }

        /// <summary>
        /// The Api operation.
        /// This is set to "Abort".
        /// </summary>
        public string Operation { get; } = "Abort";
    }
}