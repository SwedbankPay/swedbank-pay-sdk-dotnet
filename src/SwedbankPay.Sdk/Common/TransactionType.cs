namespace SwedbankPay.Sdk
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