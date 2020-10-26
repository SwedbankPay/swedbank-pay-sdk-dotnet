using SwedbankPay.Sdk.Common;

namespace SwedbankPay.Sdk.Consumers
{
    public class ConsumersResponse : IConsumersResponse
    {
        public ConsumersResponse(ConsumersResponseDto consumerResponse)
        {
            //Operations = consumerResponse.Operations.Map();
            Token = consumerResponse.Token;
        }

        public IOperationList Operations { get; }

        public string Token { get; }
    }
}