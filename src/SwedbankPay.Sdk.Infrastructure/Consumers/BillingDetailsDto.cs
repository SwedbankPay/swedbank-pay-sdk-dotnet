namespace SwedbankPay.Sdk.Consumers;

internal class BillingDetailsDto
{
    public Address BillingAddress { get; set; }

    public string Email { get; set; }

    public string Msisdn { get; set; }

    public BillingDetails Map()
    {
        var email = new EmailAddress(Email);
        var msisdn = new Msisdn(Msisdn);
        return new BillingDetails(email, msisdn, BillingAddress);
    }
}