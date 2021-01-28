namespace SwedbankPay.Sdk.PaymentInstruments
{
    /// <summary>
    /// Object describing a abort request for a payment.
    /// </summary>
    public class PaymentAbortRequest
    {
        /// <summary>
        /// Instantiates a new <see cref="PaymentAbortRequest"/> with the provided <paramref name="abortReason"/>.
        /// </summary>
        /// <param name="abortReason">Sets the reason for the abort request.</param>
        public PaymentAbortRequest(string abortReason = "CancelledByConsumer")
        {
            Payment = new PaymentAbortRequestDetails
            {
                AbortReason = abortReason
            };
        }

        /// <summary>
        /// Data detailing why the current payment is being aborted.
        /// </summary>
        public PaymentAbortRequestDetails Payment { get; }
    }
}