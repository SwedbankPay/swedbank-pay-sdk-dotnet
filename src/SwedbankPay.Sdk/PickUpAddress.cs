namespace SwedbankPay.Sdk;

/// <summary>
///     If shipIndicator set, then prefill
/// </summary>
/// 
public class PickUpAddress: IAddress
{
    /// <summary>
    /// Full name of the payer.
    /// </summary>
    public string? Name { get; set; }
    
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