namespace SwedbankPay.Sdk.PaymentInstruments.Trustly;

/// <summary>
/// Prefil information used to make Trustly payments smoother.
/// </summary>
public class TrustlyPrefillInfo
{
    /// <summary>
    /// Instantiates a <see cref="TrustlyPrefillInfo"/> with the provided parameters.
    /// </summary>
    /// <param name="firstName">The payers given name.</param>
    /// <param name="lastName">The payers family name.</param>
    public TrustlyPrefillInfo(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    /// <summary>
    /// First name of the payer.
    /// </summary>
    public string FirstName { get; }

    /// <summary>
    /// Last name of the payer.
    /// </summary>
    public string LastName { get; }
}