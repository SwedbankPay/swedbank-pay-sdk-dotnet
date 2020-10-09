namespace SwedbankPay.Sdk.Models.Shared.Consumers
{
    public class Profile
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Msisdn { get; set; }

        public AddressWithAddressee ShippingAddress { get; set; }

        public AddressWithAddressee BillingAddress { get; set; }
    }
}
