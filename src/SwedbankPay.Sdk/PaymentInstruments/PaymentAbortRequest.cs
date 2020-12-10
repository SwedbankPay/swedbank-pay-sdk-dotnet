namespace SwedbankPay.Sdk.PaymentInstruments
{
    /// <summary>
    /// Object describing a abort request for a payment.
    /// </summary>
    public class PaymentAbortRequest
    {
        /// <summary>
        /// Instantiates a new <see cref="PaymentAbortRequest"/> with the provided <paramref name="payment"/>.
        /// </summary>
        /// <param name="payment">Details of why the payment is being aborted.</param>
        public PaymentAbortRequest(PaymentAbortRequestDetails payment)
        {
            Payment = payment;
        }

        /// <summary>
        /// Data detailing why the current payment is being aborted.
        /// </summary>
        public PaymentAbortRequestDetails Payment { get; }
    }
}