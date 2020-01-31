namespace SwedbankPay.Sdk.Payments.Swish
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