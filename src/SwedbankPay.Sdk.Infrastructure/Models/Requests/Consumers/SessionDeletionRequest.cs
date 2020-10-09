namespace SwedbankPay.Sdk.Models.Requests.Consumers
{
    public class SessionDeletionRequest
    {
        public string Command { get; set; } = "session-deletion";

        public string ConsumerSessionId { get; set; }

        public string ConsumerSessionDeletionId { get; set; }
    }
}
