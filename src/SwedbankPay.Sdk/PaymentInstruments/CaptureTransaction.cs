namespace SwedbankPay.Sdk.PaymentInstruments;

/// <summary>
/// Object holding details for capturing a authorized Mobile Pay payment.
/// </summary>
public class CaptureTransaction
{
    /// <summary>
    /// Instantiates a new <see cref="CaptureTransaction"/> with the provided parameters.
    /// </summary>
    /// <param name="amount">The <seealso cref="Sdk.Amount"/> to capture.</param>
    /// <param name="vatAmount">The <see cref="Sdk.Amount"/> to capture as value added taxes.</param>
    /// <param name="description">A textual description of the capture.</param>
    /// <param name="payeeReference">Transactionally unique reference set by the merchant system.</param>
    public CaptureTransaction(Amount amount,
                                            Amount vatAmount,
                                            string description,
                                            string payeeReference)
    {
        Amount = amount;
        VatAmount = vatAmount;
        Description = description;
        PayeeReference = payeeReference;
    }

    /// <summary>
    /// The <seealso cref="Sdk.Amount"/> to be captured.
    /// </summary>
    public Amount Amount { get; }

    /// <summary>
    /// A textual description of what is being captured.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// A unique reference from the merchant system.
    /// It is set per operation to ensure an exactly-once delivery of a transactional operation.
    /// </summary>
    public string PayeeReference { get; }

    /// <summary>
    /// The payment’s VAT (Value Added Tax) amount, entered in the lowest monetary unit of the selected currency.
    /// The vatAmount entered will not affect the amount shown on the payment page, which only shows the total amount.
    /// This field is used to specify how much ofthe total amount the VAT will be.
    /// Set to 0 (zero) if there is no VAT amount charged.
    /// </summary>
    public Amount VatAmount { get; }
}