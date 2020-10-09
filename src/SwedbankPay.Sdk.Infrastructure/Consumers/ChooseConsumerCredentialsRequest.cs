namespace SwedbankPay.Sdk.Models.Requests.Consumers
{
    public class ChooseConsumerCredentialsRequest
    {
        public string Operation { get; set; } = "choose-consumer-credentials";

        public string Email { get; set; }

        public string Msisdn { get; set; }
    }
}
