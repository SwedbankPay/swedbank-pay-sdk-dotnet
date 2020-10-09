namespace SwedbankPay.Sdk.Models.Requests.Consumers
{
    public class EnrichSessionWithAddressRequest
    {
        public string Operation { get; set; } = "enrich-session-with-address";

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Address Address { get; set; }
    }
}
