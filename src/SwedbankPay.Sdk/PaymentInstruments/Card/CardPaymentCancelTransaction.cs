namespace SwedbankPay.Sdk.PaymentInstruments.Card;

/// <summary>
/// Class to hold transactional details about cancelling a card payment.
/// </summary>
public class CardPaymentCancelTransaction
{
    /// <summary>
    /// Instantiates a new <seealso cref="CardPaymentCancelTransaction"/> with the provided parameters.
    /// </summary>
    /// <param name="payeeReference">A unique payee reference for this transaction.</param>
    /// <param name="description">A textual description of the cancellation.</param>
    protected internal CardPaymentCancelTransaction(string payeeReference, string description)
    {
        PayeeReference = payeeReference;
        Description = description;
    }

    /// <summary>
    /// A human readable description of the cancellation.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// A unique reference from the merchant system.
    /// It is set per operation to ensure an exactly-once delivery of a transactional operation.
    /// </summary>
    public string PayeeReference { get; }
}