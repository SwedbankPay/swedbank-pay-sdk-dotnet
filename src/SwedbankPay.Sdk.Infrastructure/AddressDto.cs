namespace SwedbankPay.Sdk.Infrastructure;

internal record AddressDto
{
    public AddressDto(Sdk.PaymentOrder.Address address)
    {
        Name = address.Name;
        FirstName = address.FirstName;
        LastName = address.LastName;
        Email = address.Email?.ToString();
        Msisdn = address.Msisdn?.ToString();
        StreetAddress = address.StreetAddress;
        CoAddress = address.CoAddress;
        City = address.City;
        ZipCode = address.ZipCode;
        CountryCode = address.CountryCode?.ToString();
    }

    public string? Name { get; }

    public string? FirstName { get; }

    public string? LastName { get; }
    
    public string? Email { get; }

    public string? Msisdn { get; }
    
    public string? StreetAddress { get; }
    
    public string? CoAddress { get; }
    
    public string? City { get; }

    public string? ZipCode { get; }

    public string? CountryCode { get; }
}