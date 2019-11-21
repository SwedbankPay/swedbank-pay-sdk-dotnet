namespace SwedbankPay.Sdk.Consumers
{
    using Newtonsoft.Json;

    using SwedbankPay.Sdk.PaymentOrders;

    public class ShippingDetails
    {
        public EmailAddress Email { get; }

        public Msisdn Msisdn { get; }

        public Address ShippingAddress { get; }


        public ShippingDetails()
        {
        }


        [JsonConstructor]
        public ShippingDetails([JsonConverter(typeof(CustomEmailAddressConverter))]EmailAddress email, Msisdn msisdn, Address shippingAddress)
        {
            Email = email;
            Msisdn = msisdn;
            ShippingAddress = shippingAddress;
        }
    }
}
