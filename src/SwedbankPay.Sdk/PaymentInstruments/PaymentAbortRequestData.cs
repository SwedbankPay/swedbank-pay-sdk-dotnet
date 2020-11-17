namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class PaymentAbortRequestData
    {
        public PaymentAbortRequestData()
        {
            AbortReason = "CancelledByConsumer";
        }

        /// <summary>
        /// The reason why this payment is being aborted.
        /// </summary>
        public string AbortReason { get; set; }

        /// <summary>
        /// Api operation, set to 'Abort' by default.
        /// </summary>
        public string Operation { get; set; } = "Abort";
    }
}