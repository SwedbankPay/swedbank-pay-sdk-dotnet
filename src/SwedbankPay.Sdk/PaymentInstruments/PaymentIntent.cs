namespace SwedbankPay.Sdk.PaymentInstruments
{
    /// <summary>
    /// Details the inital intent of the payment.
    /// </summary>
    public enum PaymentIntent
    {
        Unknown = default,
        Authorization,
        Sale,
        AutoCapture
    }
}
