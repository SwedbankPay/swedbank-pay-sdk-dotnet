namespace SwedbankPay.Sdk.Models.Requests.Consumers
{
    public class AcquireConsumerInformationRequest
    {
        public string Operation { get; set; } = "acquire-consumer-information";

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Msisdn { get; set; }

        public Address Address { get; set; }
    }
}
