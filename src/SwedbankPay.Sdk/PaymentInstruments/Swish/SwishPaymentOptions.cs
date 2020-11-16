namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public class SwishPaymentOptions
    {
        public SwishPaymentOptions(bool ecomOnlyEnabled = false)
        {
            EcomOnlyEnabled = ecomOnlyEnabled;
        }

        /// <summary>
        /// Set to only enable Swish on browser based transactions.
        /// Otherwise to also enable Swish transactions via in-app payments.
        /// </summary>
        public bool EcomOnlyEnabled { get; }
    }
}