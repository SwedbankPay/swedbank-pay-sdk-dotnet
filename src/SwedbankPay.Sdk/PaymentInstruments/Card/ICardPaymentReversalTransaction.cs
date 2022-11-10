namespace SwedbankPay.Sdk.PaymentInstruments.Card;

/// <summary>
/// Transactional details about reversing a credit card payment.
/// </summary>
public interface ICardPaymentReversalTransaction
{
    /// <summary>
    /// The amount being reversed.
    /// </summary>
    Amount Amount { get; }

    /// <summary>
    /// A description of why the reversal happened.
    /// </summary>
    string Description { get; }

    /// <summary>
    /// A unique reference from the merchant system.
    /// It is set per operation to ensure an exactly-once delivery of a transactional operation.
    /// </summary>
    string PayeeReference { get; }

    /// <summary>
    /// The payment’s VAT (Value Added Tax) amount, entered in the lowest monetary unit of the selected currency.
    /// The vatAmount entered will not affect the amount shown on the payment page, which only shows the total amount.
    /// This field is used to specify how much ofthe total amount the VAT will be. Set to 0 (zero) if there is no VAT amount charged.
    /// </summary>
    Amount VatAmount { get; }
}