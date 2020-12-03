namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class NationalIdentifierDto
    {
        public string CountryCode { get; set; }

        public string SocialSecurityNumber { get; }
    }
}