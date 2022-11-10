namespace SwedbankPay.Sdk.PaymentInstruments.Invoice;

internal class ApprovedLegalAddressRequestDto
{
    public ApprovedLegalAddressRequestDto(ApprovedLegalAddressRequest addressee)
    {
        SocialSecurityNumber = addressee.SocialSecurityNumber;
        ZipCode = addressee.ZipCode;
    }

    public string SocialSecurityNumber { get; }

    public string ZipCode { get; }
}