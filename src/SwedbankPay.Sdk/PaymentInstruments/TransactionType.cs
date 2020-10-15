namespace SwedbankPay.Sdk.PaymentInstruments
{
    public enum TransactionType
    {
        Unknown = default,
        Authorization,
        Capture,
        Reversal,
        Cancellation,
        Sale,
        Initialization
    }
}