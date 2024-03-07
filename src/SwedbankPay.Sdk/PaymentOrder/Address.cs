namespace SwedbankPay.Sdk.PaymentOrder;

public record Address : IAddress
{
    /// <summary>
    /// Full name of the payer.
    /// </summary>
    public string? Name { get; set; }
        
    /// <summary>
    /// Payers first name.
    /// If the payer is a company, use only firstName.
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// Payers first name.
    /// If payer is a company, use only firstName.
    /// </summary>
    public string? LastName { get; set; }
    
    /// <summary>
    /// Payers email address.
    /// </summary>
    public EmailAddress? Email { get; set; }

    /// <summary>
    /// Payers primary MSISDN.
    /// Also known as phone number.
    /// </summary>
    public Msisdn? Msisdn { get; set; }

    /// <summary>
    /// Street address of the payers residence.
    /// </summary>
    public string? StreetAddress { get; set; }
    
    /// <summary>
    /// Payers C/O address (if applicable).
    /// </summary>
    public string? CoAddress { get; set; }
    
    /// <summary>
    /// Payers city of residence.
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// Zip code of the payers residence.
    /// </summary>
    public string? ZipCode { get; set; }

    /// <summary>
    /// Country code of the payer.
    /// </summary>
    public CountryCode? CountryCode { get; set; }
}