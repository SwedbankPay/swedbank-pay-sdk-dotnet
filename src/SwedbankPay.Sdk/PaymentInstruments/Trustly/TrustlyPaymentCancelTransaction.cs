namespace SwedbankPay.Sdk.PaymentInstruments.Trustly;

/// <summary>
/// Transactional details for cancelling a Trustly payment.
/// </summary>
public class TrustlyPaymentCancelTransaction
{
    /// <summary>
    /// Instantiates a new <see cref="TrustlyPaymentCancelTransaction"/> with the provided parameters.
    /// </summary>
    /// <param name="payeeReference">Transactionally unique reference from the merchant system.</param>
    /// <param name="description">A textual description of the cancellation.</param>
    protected internal TrustlyPaymentCancelTransaction(string payeeReference, string description)
    {
        PayeeReference = payeeReference;
        Description = description;
    }

    /// <summary>
    /// A textual description of this cancellation.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// A unique reference from the merchant system.
    /// It is set per operation to ensure an exactly-once delivery of a transactional operation.
    /// </summary>
    public string PayeeReference { get; }
}