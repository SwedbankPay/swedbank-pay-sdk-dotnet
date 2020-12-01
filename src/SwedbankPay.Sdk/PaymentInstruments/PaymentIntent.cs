namespace SwedbankPay.Sdk.PaymentInstruments
{
    /// <summary>
    /// Details the inital intent of the payment.
    /// </summary>
    public enum PaymentIntent
    {
        /// <summary>
        /// The intent is not yet mapped, or corrupted.
        /// </summary>
        Unknown = default,
        /// <summary>
        /// The intent of the payment request is a authorization.
        /// </summary>
        Authorization,
        /// <summary>
        /// THe intent of the payment request is a Sale.
        /// </summary>
        Sale,
        /// <summary>
        /// The intent of the payment is an automatic capture.
        /// </summary>
        AutoCapture
    }
}
