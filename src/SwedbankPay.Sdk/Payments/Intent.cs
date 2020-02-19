namespace SwedbankPay.Sdk.Payments
{
    public enum Intent
    {
        Unknown = default,
        Authorization,
        Sale,
        AutoCapture
    }
}
