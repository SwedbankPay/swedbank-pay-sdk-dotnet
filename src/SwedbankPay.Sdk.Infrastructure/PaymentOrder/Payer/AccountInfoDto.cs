using SwedbankPay.Sdk.PaymentOrder.Payer;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.Payer;

internal record AccountInfoDto
{
    public AccountInfoDto(AccountInfo? accountInfo)
    {
        AccountAgeIndicator = accountInfo?.AccountAgeIndicator?.Value;
        AccountChangeIndicator = accountInfo?.AccountChangeIndicator?.Value;
        AccountPwdChangeIndicator = accountInfo?.AccountPwdChangeIndicator?.Value;
        AddressMatchIndicator = accountInfo?.AddressMatchIndicator ?? false;
        ShippingAddressUsageIndicator = accountInfo?.ShippingAddressUsageIndicator?.Value;
        ShippingNameIndicator = accountInfo?.ShippingNameIndicator?.Value;
        SuspiciousAccountActivity = accountInfo?.SuspiciousAccountActivity?.Value;
    }
    
    public string? AccountAgeIndicator { get; set; }
    public string? AccountChangeIndicator { get; set; }
    public string? AccountPwdChangeIndicator { get; set; }

    // TODO: Not Used? Remove?
    public bool AddressMatchIndicator { get; set; }
    public string? ShippingAddressUsageIndicator { get; set; }
    public string? ShippingNameIndicator { get; set; }
    public string? SuspiciousAccountActivity { get; set; }
}