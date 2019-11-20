namespace SwedbankPay.Sdk.Consumers
{
    using Newtonsoft.Json;

    using SwedbankPay.Sdk.PaymentOrders;

    public class ShippingDetails
    {
        public EmailAddress Email { get; }

        public string Msisdn { get; }

        public Address ShippingAddress { get; }


        public ShippingDetails()
        {
        }


        [JsonConstructor]
        public ShippingDetails([JsonConverter(typeof(CustomEmailAddressConverter))]EmailAddress email, string msisdn, Address shippingAddress)
        {
            Email = email;
            Msisdn = msisdn;
            ShippingAddress = shippingAddress;
        }
    }
}
