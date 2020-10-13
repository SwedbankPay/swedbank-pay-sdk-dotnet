namespace SwedbankPay.Sdk.Payments
{
    public enum PaymentIntent
    {
        Unknown = default,
        Authorization,
        Sale,
        AutoCapture
    }
}
