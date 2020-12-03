namespace SwedbankPay.Sdk.Consumers
{
    internal class ConsumersResponse : IConsumersResponse
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