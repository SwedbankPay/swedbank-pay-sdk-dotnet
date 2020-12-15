namespace SwedbankPay.Sdk.Consumers
{
    internal class ShippingDetailsDto
    {
        public string Email { get; set; }

        public string Msisdn { get; set; }

        public Address ShippingAddress { get; set; }

        internal ShippingDetails Map()
        {
            var email = new EmailAddress(Email);
            var msisdn = new Msisdn(Msisdn);
            return new ShippingDetails(email, msisdn, ShippingAddress);
        }
    }
}