namespace SwedbankPay.Sdk.PaymentInstruments.Card;

/// <summary>
/// Contains details about cancelling a card payment.
/// </summary>
public class CardPaymentCancelRequest
{
    /// <summary>
    /// Instantiates a new <seealso cref="CardPaymentCancelRequest"/> with the provided parameters.
    /// </summary>
    /// <param name="payeeReference">A unique payee reference for this transaction.</param>
    /// <param name="description">A textual description of the cancellation.</param>
    public CardPaymentCancelRequest(string payeeReference, string description)
    {
        Transaction = new CardPaymentCancelTransaction(payeeReference, description);
    }

    /// <summary>
    /// Transactional details about the cancellation.
    /// </summary>
    public CardPaymentCancelTransaction Transaction { get; }
}