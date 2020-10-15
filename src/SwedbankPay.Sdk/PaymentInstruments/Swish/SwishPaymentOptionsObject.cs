namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public class SwishPaymentOptionsObject
    {
        public SwishPaymentOptionsObject(bool ecomOnlyEnabled = false)
        {
            EcomOnlyEnabled = ecomOnlyEnabled;
        }


        public bool EcomOnlyEnabled { get; }
    }
}