namespace SwedbankPay.Sdk.Payments.SwishPayments
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