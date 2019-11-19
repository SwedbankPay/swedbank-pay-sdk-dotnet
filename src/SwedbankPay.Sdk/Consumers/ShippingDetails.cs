namespace SwedbankPay.Sdk.Consumers
{
    public class ShippingDetails
    {
        public string Email { get; protected set; }

        public string Msisdn { get; protected set; }

        public Address ShippingAddress { get; protected set; }
    }
}
