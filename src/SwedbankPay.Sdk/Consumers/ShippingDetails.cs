using Newtonsoft.Json;

namespace SwedbankPay.Sdk.Consumers
{
    public class ShippingDetails
    {
        public ShippingDetails()
        {
        }


        [JsonConstructor]
        public ShippingDetails(EmailAddress email, Msisdn msisdn, Address shippingAddress)
        {
            Email = email;
            Msisdn = msisdn;
            ShippingAddress = shippingAddress;
        }


        public EmailAddress Email { get; }

        public Msisdn Msisdn { get; }

        public Address ShippingAddress { get; }
    }
}