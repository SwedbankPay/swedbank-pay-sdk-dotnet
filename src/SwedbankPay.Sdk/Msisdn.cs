namespace SwedbankPay.Sdk;

/// <summary>
/// Object to hold a consumers/payers <seealso cref="Msisdn"/> information.
/// </summary>
public class Msisdn
{
    private readonly string _value;

    /// <summary>
    /// Creates a new <seealso cref="Msisdn"/>
    /// </summary>
    /// <param name="msisdn">The payers MSISDN.</param>
    public Msisdn(string msisdn)
    {
        if (string.IsNullOrWhiteSpace(msisdn))
        {
            throw new ArgumentException($"Invalid msisdn: {msisdn}", nameof(msisdn));
        }

        _value = msisdn;
    }

    /// <summary>
    /// Method to validate a provided <seealso cref="string"/>.
    /// </summary>
    /// <param name="msisdn">The <seealso cref="string"/> to validate.</param>
    /// <param name="validMsisdn">Valid <see cref="Msisdn"/> if can be parsed, <code>null</code> otherwise.</param>
    /// <returns>false if not valid, true otherwise.</returns>
    public static bool TryParse(string msisdn, out Msisdn? validMsisdn)
    {
        if (string.IsNullOrWhiteSpace(msisdn))
        {
            validMsisdn = null;
            return false;
        }

        validMsisdn = new Msisdn(msisdn);
        return true;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns><inheritdoc/></returns>
    public override string ToString()
    {
        return _value;
    }
    /// <summary>
    /// Gets the msisdn.
    /// </summary>
    public string Value => _value;
}