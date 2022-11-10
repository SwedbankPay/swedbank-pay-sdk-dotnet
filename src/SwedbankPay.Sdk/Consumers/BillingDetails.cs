namespace SwedbankPay.Sdk.Consumers;

/// <summary>
/// Holds billing details about a consumer.
/// </summary>
public class BillingDetails
{
    /// <summary>
    /// Instantiates a new <see cref="BillingDetails"/> with the provided parameters.
    /// </summary>
    /// <param name="email">The consumers email address.</param>
    /// <param name="msisdn">The consumers MSISDN.</param>
    /// <param name="billingAddress">The consumers billing address.</param>
    public BillingDetails(EmailAddress email, Msisdn msisdn, Address billingAddress)
    {
        Email = email;
        Msisdn = msisdn;
        BillingAddress = billingAddress;
    }

    /// <summary>
    /// The payers billing address
    /// </summary>
    public Address BillingAddress { get; }

    /// <summary>
    /// The payers email address
    /// </summary>
    public EmailAddress Email { get; }

    /// <summary>
    ///     The MSISDN (mobile phone number) of the payer. Format Sweden: +46707777777. Format Norway: +4799999999.
    /// </summary>
    public Msisdn Msisdn { get; }
}