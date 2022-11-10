namespace SwedbankPay.Sdk.PaymentInstruments.Swish;

/// <summary>
/// Transactional information about a Swish sale.
/// </summary>
public class SwishPaymentSaleTransaction
{
    /// <summary>
    /// Instantiates a new <see cref="SwishPaymentSaleTransaction"/> with the provided <paramref name="msisdn"/>.
    /// </summary>
    /// <param name="msisdn">The payers <seealso cref="Msisdn"/>.</param>
    public SwishPaymentSaleTransaction(Msisdn msisdn)
    {
        Msisdn = msisdn;
    }

    /// <summary>
    /// Prefill information about the payer.
    /// </summary>
    public Msisdn Msisdn { get; }
}
