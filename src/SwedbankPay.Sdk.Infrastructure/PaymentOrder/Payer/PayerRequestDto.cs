namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.Payer;

internal record PayerRequestDto
{
    public PayerRequestDto(Sdk.PaymentOrder.Payer.Payer payer)
    {
        FirstName = payer.FirstName;
        LastName = payer.LastName;
        PayerReference = payer.PayerReference;
        Email = payer.Email?.ToString();
        Msisdn = payer.Msisdn?.ToString();
        WorkPhoneNumber = payer.WorkPhoneNumber?.ToString();
        HomePhoneNumber = payer.HomePhoneNumber?.ToString();
        BillingAddress = payer.BillingAddress != null ? new AddressDto(payer.BillingAddress) :  null;
        ShippingAddress = payer.ShippingAddress != null ? new AddressDto(payer.ShippingAddress) : null;
        AccountInfo = new AccountInfoDto(payer.AccountInfo);
    }

    public string? FirstName { get; }
    
    public string? LastName { get; }
    
    public string? PayerReference { get; }
    
    public string? Email { get; }

    public string? Msisdn { get; }

    public string? WorkPhoneNumber { get; }
    
    public string? HomePhoneNumber { get; }
    
    public AddressDto? BillingAddress { get; }
    
    public AddressDto? ShippingAddress { get; }
    
    public AccountInfoDto? AccountInfo { get; }
}