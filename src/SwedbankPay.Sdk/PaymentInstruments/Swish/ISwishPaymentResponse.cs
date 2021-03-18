namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    /// <summary>
    /// Response object for a Swish payment and its
    /// available operations.
    /// </summary>
    public interface ISwishPaymentResponse
    {
        /// <summary>
        /// The current Swish payment.
        /// </summary>
        ISwishPayment Payment { get; }

        /// <summary>
        /// Operations available on this Swish payment.
        /// </summary>
        ISwishPaymentOperations Operations { get; }
    }
}