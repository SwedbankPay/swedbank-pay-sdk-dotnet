namespace SwedbankPay.Sdk;

/// <summary>
/// Holds details about a users current address.
/// </summary>
public class Address: IAddress
{
    /// <summary>
    /// The payers city of residence.
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// The C/O address of the payer, if applicable.
    /// </summary>
    public string CoAddress { get; set; }

    /// <summary>
    /// The country code of the payers country of residence.
    /// </summary>
    public CountryCode CountryCode { get; set; }

    /// <summary>
    /// Payers email address.
    /// </summary>
    public EmailAddress Email { get; set; }

    /// <summary>
    /// Payers first name.
    /// If the payer is a company, use only firstName.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Payers first name.
    /// If payer is a company, use only firstName.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Payers primary MSISDN.
    /// Also known as phone number.
    /// </summary>
    public Msisdn Msisdn { get; set; }

    /// <summary>
    /// Payers street address in their city of residence.
    /// </summary>
    public string StreetAddress { get; set; }

    /// <summary>
    /// Payers zip code of their country of residence.
    /// </summary>
    public string ZipCode { get; set; }
}