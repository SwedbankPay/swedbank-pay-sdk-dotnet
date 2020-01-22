namespace SwedbankPay.Sdk
{
    public enum TransactionType
    {
        Authorization,
        Capture,
        Reversal,
        Cancellation,
        Sale,
        Initialization
    }
}