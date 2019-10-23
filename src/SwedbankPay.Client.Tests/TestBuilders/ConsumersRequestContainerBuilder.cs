using SwedbankPay.Client.Models.Request;

namespace SwedbankPay.Client.Tests.TestBuilders
{
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
