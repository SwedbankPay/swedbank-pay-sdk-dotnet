namespace SwedbankPay.Sdk.PaymentInstruments.Vipps;

/// <summary>
/// Transactional details to cancel a Vipps payment.
/// </summary>
public class CancelTransaction
{
    /// <summary>
    /// Instantiates a new <see cref="CancelTransaction"/> with the provided parameters.
    /// </summary>
    /// <param name="payeeReference">A transactionally unique reference for this cancellation.</param>
    /// <param name="description">A textual description of this cancellation.</param>
    public CancelTransaction(string payeeReference, string description)
    {
        PayeeReference = payeeReference;
        Description = description;
    }

    /// <summary>
    /// Textual description of the cancellation.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// A unique reference from the merchant system.
    /// It is set per operation to ensure an exactly-once delivery of a transactional operation.
    /// </summary>
    public string PayeeReference { get; }
}