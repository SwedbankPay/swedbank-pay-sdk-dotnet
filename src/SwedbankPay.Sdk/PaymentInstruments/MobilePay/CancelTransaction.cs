namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay;

/// <summary>
/// Wraps a cancel transaction for Mobile Pay payment instrument.
/// </summary>
public class CancelTransaction
{
    /// <summary>
    /// Instantiates a <see cref="CancelTransaction"/> with the provided parameters.
    /// </summary>
    /// <param name="payeeReference">A transactionally unique reference set by the merchant system.</param>
    /// <param name="description">A textual description of the cancellation.</param>
    public CancelTransaction(string payeeReference, string description)
    {
        PayeeReference = payeeReference;
        Description = description;
    }

    /// <summary>
    /// A textual description for the cancellation.
    /// </summary>
    public string Description { get; }

    /// <summary>
    ///  A unique reference from the merchant system.
    ///  It is set per operation to ensure an exactly-once delivery of a transactional operation.
    /// </summary>
    public string PayeeReference { get; }
}
