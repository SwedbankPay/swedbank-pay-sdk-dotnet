namespace SwedbankPay.Sdk.Models.Requests.Consumers
{
    public class CompleteProfileRegistrationRequest
    {
        public string Command { get; set; } = "profile-registration";

        public string ConsumerSessionId { get; set; }

        public string Culture { get; set; }
    }
}
