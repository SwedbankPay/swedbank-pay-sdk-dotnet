namespace SwedbankPay.Sdk.PaymentInstruments.Trustly;

/// <summary>
/// API request to cancel a Trustly payment.
/// </summary>
public class TrustlyPaymentCancelRequest
{
    /// <summary>
    /// Instantiates a new <see cref="TrustlyPaymentCancelRequest"/> with the provided parameters.
    /// </summary>
    /// <param name="payeeReference">Transactionally unique reference from the merchant system.</param>
    /// <param name="description">A textual description of the cancellation.</param>
    public TrustlyPaymentCancelRequest(string payeeReference, string description)
    {
        Transaction = new TrustlyPaymentCancelTransaction(payeeReference, description);
    }

    /// <summary>
    /// Transactional details about cancelling a Trustly payment.
    /// </summary>
    public TrustlyPaymentCancelTransaction Transaction { get; }
}