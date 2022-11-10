namespace SwedbankPay.Sdk.PaymentInstruments;

/// <summary>
/// Gives a summary for the Value Added Taxes for a order line.
/// </summary>
public class VatSummary
{
    /// <summary>
    /// Instantiates a <see cref="VatSummary"/> with the provided parameters.
    /// </summary>
    /// <param name="amount">Total price of the order line.</param>
    /// <param name="vatPercent">Percent value of the VAT multiplied by 100.</param>
    /// <param name="vatAmount">The VAT for the orderline.</param>
    public VatSummary(Amount amount,
                      string vatPercent,
                      Amount vatAmount)
    {
        Amount = amount;
        VatPercent = vatPercent;
        VatAmount = vatAmount;
    }

    /// <summary>
    /// Total price for this order line - entered in the lowest momentary units of the selected currency.
    /// </summary>
    public Amount Amount { get; }

    /// <summary>
    /// The percent value of the VAT multiplied by 100.
    /// Supported values : 0, 600, 800, 1000, 1200, 1400, 1500, 2200, 2400, 2500.
    /// </summary>
    public string VatPercent { get; set; }

    /// <summary>
    /// VAT Amount entered in the lowest momentary units of the selected currency.
    /// </summary>
    public Amount VatAmount { get; }

}
