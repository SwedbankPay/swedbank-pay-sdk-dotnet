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
            _consumersRequestContainer.ConsumersRequest.CountryCode = CountryCode.SE;
            return this;
        }
        
        public ConsumersRequestContainer Build()
        {
            return _consumersRequestContainer;
        }
    }
}
