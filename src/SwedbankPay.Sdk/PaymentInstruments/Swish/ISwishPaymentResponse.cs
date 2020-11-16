namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
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