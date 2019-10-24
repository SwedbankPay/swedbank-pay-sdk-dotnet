namespace SwedbankPay.Sdk.Tests.TestBuilders
{
    using SwedbankPay.Sdk.Consumers;

    public class ConsumersRequestContainerBuilder
    {
        private ConsumersRequestContainer _consumersRequestContainer = new ConsumersRequestContainer
        {
            ConsumersRequest = new ConsumersRequest()
        };
    

        public ConsumersRequestContainerBuilder WithTestValues()
        {
            _consumersRequestContainer.ConsumersRequest.ConsumerCountryCode = "SE";
            return this;
        }

        public ConsumersRequestContainerBuilder WithEmtptyConsumerCountryCode()
        {
           _consumersRequestContainer.ConsumersRequest.ConsumerCountryCode = "";
            return this;
        }

        public ConsumersRequestContainer Build()
        {
            return _consumersRequestContainer;
        }
    }
}
