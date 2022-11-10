namespace SwedbankPay.Sdk.PaymentInstruments.Card;

/// <summary>
/// Information about a card holder
/// </summary>
public interface ICardholder
{
    /// <summary>
    /// Contains information about the account for the card
    /// </summary>
    AccountInfo AccountInfo { get; set; }

    /// <summary>
    /// The card holders billing address
    /// </summary>
    Address BillingAddress { get; set; }

    /// <summary>
    /// Card holders email address
    /// </summary>
    EmailAddress Email { get; set; }

    /// <summary>
    /// Card holders first name
    /// </summary>
    string FirstName { get; set; }

    /// <summary>
    /// Card holders first name
    /// </summary>
    string LastName { get; set; }

    /// <summary>
    /// The MSISDN (mobile phone number) of the card holders home
    /// Format Sweden: +46xxxxxxxxx. Format Norway: +47xxxxxxxx
    /// </summary>
    Msisdn HomePhoneNumber { get; set; }

    /// <summary>
    /// The MSISDN (mobile phone number) of the card phone
    /// Format Sweden: +46xxxxxxxxx. Format Norway: +47xxxxxxxx
    /// </summary>
    Msisdn Msisdn { get; set; }

    /// <summary>
    /// Card holders shipping address
    /// </summary>
    Address Shippingaddress { get; set; }

    /// <summary>
    /// The MSISDN (mobile phone number) of the card holders work phone
    /// Format Sweden: +46xxxxxxxxx. Format Norway: +47xxxxxxxx
    /// </summary>
    Msisdn WorkPhoneNumber { get; set; }
}