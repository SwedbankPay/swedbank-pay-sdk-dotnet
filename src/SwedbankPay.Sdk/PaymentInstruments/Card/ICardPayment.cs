namespace SwedbankPay.Sdk.PaymentInstruments.Card;

/// <summary>
/// Describes a credt card payment.
/// </summary>
public interface ICardPayment : IIdentifiable, IPaymentInstrument
{
    /// <summary>
    /// The available authorization transactions for this payment.
    /// </summary>
    ICardPaymentAuthorizationListResponse Authorizations { get; }

    /// <summary>
    /// The created recurrenceToken, if <seealso cref="Operation.Verify"/>, <seealso cref="Operation.Recur"/> generateRecurrenceToken: true was used.
    /// </summary>
    string RecurrenceToken { get; }
}