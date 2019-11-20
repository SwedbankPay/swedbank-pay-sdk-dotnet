namespace SwedbankPay.Sdk.Tests.TestBuilders
{
    using SwedbankPay.Sdk.Consumers;

    public class ConsumersRequestContainerBuilder
    {
        private ConsumersRequestContainer consumersRequestContainer = new ConsumersRequestContainer
        {
            ConsumersRequest = new ConsumersRequest()
        };


        public ConsumersRequestContainerBuilder WithTestValues()
        {
            this.consumersRequestContainer.ConsumersRequest.ConsumerCountryCode = CountryCode.SE;
            return this;
        }

        public ConsumersRequestContainer Build()
        {
            return this.consumersRequestContainer;
        }
    }
}
