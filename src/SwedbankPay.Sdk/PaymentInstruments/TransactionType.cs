namespace SwedbankPay.Sdk.PaymentInstruments;

/// <summary>
/// Enum to detail the transaction type.
/// </summary>
public enum TransactionType
{
    /// <summary>
    /// Transaction type is either corrupt or not known to us yet.
    /// </summary>
    Unknown = default,

    /// <summary>
    /// Transaction was used to authorize a payment.
    /// </summary>
    Authorization,

    /// <summary>
    /// Transaction was used to capture funds of a payment.
    /// </summary>
    Capture,

    /// <summary>
    /// Transaction was used to reverse funds of a payment.
    /// </summary>
    Reversal,

    /// <summary>
    /// Transaction was used to cancel a payment and any remaining authorized funds.
    /// </summary>
    Cancellation,

    /// <summary>
    /// Transaction was used as a one-phase sale.
    /// </summary>
    Sale,

    /// <summary>
    /// Transaction was used to initialize a payment.
    /// </summary>
    Initialization,

    /// <summary>
    /// Transaction was used to verify a payment
    /// </summary>
    Verification
}