namespace SwedbankPay.Sdk.PaymentInstruments
{
    /// <summary>
    /// Enum to detail the transaction type.
    /// </summary>
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