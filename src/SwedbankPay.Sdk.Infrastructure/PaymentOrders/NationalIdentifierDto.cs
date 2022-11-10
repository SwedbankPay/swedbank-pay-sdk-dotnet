namespace SwedbankPay.Sdk.PaymentOrders;

internal class NationalIdentifierDto
{
    public NationalIdentifierDto() { }

    public NationalIdentifierDto(NationalIdentifier nationalIdentifier)
    {
        if(nationalIdentifier == null)
        {
            return;
        }
        CountryCode = nationalIdentifier.CountryCode.ToString();
        SocialSecurityNumber = nationalIdentifier.SocialSecurityNumber;
    }

    public string CountryCode { get; set; }

    public string SocialSecurityNumber { get; }
}