namespace SwedbankPay.Sdk
{
    /// <summary>
    ///     Payment Instrument
    /// </summary>

    public enum PaymentInstrument
    {
        Unknown = default,
        Invoice,
        MobilePay,
        CreditCard,
        Swish,
        Vipps,
        DirectDebit,
        Trustly
    }
}
