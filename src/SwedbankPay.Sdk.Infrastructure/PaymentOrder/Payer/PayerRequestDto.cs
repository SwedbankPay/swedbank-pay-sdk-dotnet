using SwedbankPay.Sdk.PaymentOrder.Payer;

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
        BillingAddress = new AddressDto(payer.BillingAddress);
        ShippingAddress = new AddressDto(payer.ShippingAddress);
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