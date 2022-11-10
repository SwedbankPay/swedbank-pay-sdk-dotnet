namespace SwedbankPay.Sdk.PaymentInstruments.Card;

/// <summary>
/// Transactional details about a response for a credit card
/// recurring payment.
/// </summary>
public interface ICardPaymentRecurResponse
{
    /// <summary>
    /// The current recur payment.
    /// </summary>
    ICardPaymentRecurResponseDetails Payment { get; }

    /// <summary>
    /// The available operations on this payment.
    /// </summary>
    ICardPaymentOperations Operations { get; }
}