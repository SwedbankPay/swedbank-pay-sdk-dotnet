namespace SwedbankPay.Sdk.PaymentInstruments.Card;

internal class CardholderDto
{
    public CardholderDto(Cardholder cardholder)
    {
        if(cardholder == null)
        {
            return;
        }
        AccountInfo = new AccountInfoDto(cardholder.AccountInfo);
        BillingAddress = new AddressDto(cardholder.BillingAddress);
        Email = cardholder.Email.ToString();
        FirstName = cardholder.FirstName;
        HomePhoneNumber = cardholder.HomePhoneNumber?.ToString();
        LastName = cardholder.LastName;
        Msisdn = cardholder.Msisdn?.ToString();
        Shippingaddress = new AddressDto(cardholder.Shippingaddress);
        WorkPhoneNumber = cardholder.WorkPhoneNumber?.ToString();
    }

    public AccountInfoDto AccountInfo { get; set; }
    public AddressDto BillingAddress { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string HomePhoneNumber { get; set; }
    public string LastName { get; set; }
    public string Msisdn { get; set; }
    public AddressDto Shippingaddress { get; set; }
    public string WorkPhoneNumber { get; set; }
}