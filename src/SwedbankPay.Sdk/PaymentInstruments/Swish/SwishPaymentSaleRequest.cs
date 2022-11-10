namespace SwedbankPay.Sdk.PaymentInstruments.Swish;

/// <summary>
/// API request to create a Swish sale.
/// </summary>
public class SwishPaymentSaleRequest
{
    /// <summary>
    /// Instantiates a new <see cref="SwishPaymentSaleRequest"/> with the provided <paramref name="msisdn"/>.
    /// </summary>
    /// <param name="msisdn">The payers <seealso cref="Msisdn"/>.</param>
    public SwishPaymentSaleRequest(Msisdn msisdn)
    {
        Transaction = new SwishPaymentSaleTransaction(msisdn);
    }

    /// <summary>
    /// Transaction with prefill information about the consumer.
    /// </summary>
    public SwishPaymentSaleTransaction Transaction { get; }
}
