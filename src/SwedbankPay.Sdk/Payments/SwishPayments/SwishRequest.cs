namespace SwedbankPay.Sdk.Payments.SwishPayments
{
    public class SwishRequest
    {
        public SwishRequest(bool ecomOnlyEnabled = false)
        {
            EcomOnlyEnabled = ecomOnlyEnabled;
        }


        public bool EcomOnlyEnabled { get; }
    }
}