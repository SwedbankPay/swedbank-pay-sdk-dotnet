namespace SwedbankPay.Sdk.PaymentInstruments.Card;

/// <summary>
/// Contains the details about why a payment is being aborted.
/// </summary>
public class CardPaymentAbortPayment
{
    /// <summary>
    /// The API operation to be performed; "Abort".
    /// </summary>
    public string Operation { get; } = "Abort";

    /// <summary>
    /// Instantiates a new <see cref="CardPaymentAbortPayment"/> with the provided <paramref name="abortReason"/>.
    /// </summary>
    /// <param name="abortReason">The textual reason for this abort.</param>
    public CardPaymentAbortPayment(string abortReason)
    {
        AbortReason = abortReason;
    }

    /// <summary>
    /// The reason for why the payment is being aborted
    /// </summary>
    public string AbortReason { get; }
}