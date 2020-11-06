namespace SwedbankPay.Sdk.Consumers
{
    public class ConsumersResponse : IConsumersResponse
    {
        public ConsumersResponse(ConsumersResponseDto consumerResponse)
        {
            Operations = new ConsumerOperations(consumerResponse.Operations.Map());
            Token = consumerResponse.Token;
        }

        public ConsumerOperations Operations { get; }

        public string Token { get; }
    }
}