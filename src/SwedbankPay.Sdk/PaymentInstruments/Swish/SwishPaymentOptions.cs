namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    /// <summary>
    /// Object for setting E-Commerce options for a Swish payment.
    /// </summary>
    public class SwishPaymentOptions
    {
        /// <summary>
        /// Instantiates a <see cref="SwishPaymentOptions"/> with the provided <paramref name="enableEcomOnly"/>.
        /// </summary>
        /// <param name="enableEcomOnly">Set this to disable in-app payments for the payment.</param>
        public SwishPaymentOptions(bool enableEcomOnly = false)
        {
            EnableEcomOnly = enableEcomOnly;
        }

        /// <summary>
        /// Set to only enable Swish on browser based transactions.
        /// Otherwise to also enable Swish transactions via in-app payments.
        /// </summary>
        public bool EnableEcomOnly { get; }
    }
}