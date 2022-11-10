using System;

namespace SwedbankPay.Sdk.PaymentInstruments;

/// <summary>
/// Object holding a payers legal address.
/// </summary>
public class LegalAddress
{
    /// <summary>
    /// Instantiates a new <see cref="LegalAddress"/> with the provided parameters.
    /// </summary>
    /// <param name="id">The resource ID.</param>
    /// <param name="addressee">Full name of the addressee.</param>
    /// <param name="coAddress">C/O address, if applicable.</param>
    /// <param name="streetAddress">The payers street address.</param>
    /// <param name="zipCode">The payers zip code.</param>
    /// <param name="city">The payers city of residence.</param>
    /// <param name="countryCode">The payers country code of residence.</param>
    public LegalAddress(Uri id, string addressee, string coAddress, string streetAddress, string zipCode, string city, string countryCode)
    {
        Id = id;
        Addressee = addressee;
        CoAddress = coAddress;
        StreetAddress = streetAddress;
        ZipCode = zipCode;
        City = city;
        CountryCode = countryCode;
    }

    /// <summary>
    /// A unique <seealso cref="Uri"/> to access this legal address resource.
    /// </summary>
    public Uri Id { get; }

    /// <summary>
    /// Full name of the addressee, the receiver of the shipped goods for the current payment.
    /// </summary>
    public string Addressee { get; }

    /// <summary>
    /// Payers c/o address, if applicable.
    /// </summary>
    public string CoAddress { get; }

    /// <summary>
    /// The street address of the payer.
    /// </summary>
    public string StreetAddress { get; }

    /// <summary>
    /// The zip code of the payer.
    /// </summary>
    public string ZipCode { get; }

    /// <summary>
    /// The city of the payers residence.
    /// </summary>
    public string City { get; }

    /// <summary>
    /// The country code of the payers residence.
    /// </summary>
    public string CountryCode { get; }
}