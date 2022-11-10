namespace SwedbankPay.Sdk.PaymentInstruments.Card;

/// <summary>
/// Holds transactional details about a payment being aborted.
/// </summary>
public class CardPaymentAbortRequest
{
    /// <summary>
    /// Instantiates a new <see cref="CardPaymentAbortRequest"/> with the provided <paramref name="abortReason"/>.
    /// </summary>
    /// <param name="abortReason">The reason for the abort.</param>
    public CardPaymentAbortRequest(string abortReason)
    {
        Payment = new CardPaymentAbortPayment(abortReason);
    }

    /// <summary>
    /// Payment details of why it's being aborted.
    /// </summary>
    public CardPaymentAbortPayment Payment { get; }
}