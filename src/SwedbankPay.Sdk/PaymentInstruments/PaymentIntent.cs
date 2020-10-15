namespace SwedbankPay.Sdk.PaymentInstruments
{
    public enum PaymentIntent
    {
        Unknown = default,
        Authorization,
        Sale,
        AutoCapture
    }
}
