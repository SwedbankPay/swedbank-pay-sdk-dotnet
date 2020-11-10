namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public class SwishPaymentOptions
    {
        public SwishPaymentOptions(bool ecomOnlyEnabled = false)
        {
            EcomOnlyEnabled = ecomOnlyEnabled;
        }


        public bool EcomOnlyEnabled { get; }
    }
}