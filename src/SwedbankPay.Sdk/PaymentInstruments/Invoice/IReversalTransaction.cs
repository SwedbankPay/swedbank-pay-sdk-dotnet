namespace SwedbankPay.Sdk.PaymentInstruments.Invoice;

/// <summary>
/// Transactional details for reversing a previously captured invoice payment.
/// </summary>
public interface IReversalTransaction
{
    /// <summary>
    /// The <seealso cref="Sdk.Amount"/> to reverse on the current payment.
    /// </summary>
    Amount Amount { get; }

    /// <summary>
    /// A textual description for the reversal.
    /// </summary>
    string Description { get; }

    /// <summary>
    /// A unique reference from the merchant system.
    /// It is set per operation to ensure an exactly-once delivery of a transactional operation.
    /// PayeeReference is used as an invoice/receipt number, if the receiptReference is not defined.
    /// </summary>
    string PayeeReference { get; }

    /// <summary>
    /// The payment’s VAT (Value Added Tax) amount, entered in the lowest monetary unit of the selected currency.
    /// The vatAmount entered will not affect the amount shown on the payment page, which only shows the total amount.
    /// This field is used to specify how much of the total amount the VAT will be.
    /// Set to 0 (zero) if there is no VAT amount charged.
    /// </summary>
    Amount VatAmount { get; }

    /// <summary>
    /// The receiptReference is a reference from the merchant system.
    /// This reference is used as an invoice/receipt number.
    /// </summary>
    string ReceiptReference { get; }
}