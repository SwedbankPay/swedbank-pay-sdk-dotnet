namespace SwedbankPay.Sdk.PaymentInstruments;

/// <summary>
/// Holds a <seealso cref="Sdk.Msisdn"/> object used to
/// pre-fill information in the payment window.
/// </summary>
public class PrefillInfo
{
    /// <summary>
    /// Instantiates a new <see cref="PrefillInfo"/> using the provided <paramref name="msisdn"/>.
    /// </summary>
    /// <param name="msisdn">The payers phone number to pre-fill in the payment window.</param>
    public PrefillInfo(Msisdn msisdn)
    {
        Msisdn = msisdn;
    }


    /// <summary>
    /// MSISDN of the payer, with landcode.
    /// </summary>
    public Msisdn Msisdn { get; }
}