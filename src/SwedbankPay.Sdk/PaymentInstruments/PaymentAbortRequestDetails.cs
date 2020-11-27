namespace SwedbankPay.Sdk.PaymentInstruments
{
    /// <summary>
    /// Contains the deails about aborting a payment.
    /// </summary>
    public class PaymentAbortRequestDetails
    {
        /// <summary>
        /// Constructs with default values.
        /// </summary>
        public PaymentAbortRequestDetails()
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
        public string Operation { get; } = "Abort";
    }
}