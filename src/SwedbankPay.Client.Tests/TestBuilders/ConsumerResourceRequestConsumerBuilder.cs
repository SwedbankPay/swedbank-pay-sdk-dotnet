using SwedbankPay.Client.Models.Request;

namespace SwedbankPay.Client.Tests.TestBuilders
{
    public class ConsumerResourceRequestContainerBuilder
    {
        private ConsumerResourceRequestContainer _consumerResourceRequestContainer = new ConsumerResourceRequestContainer
        {
            ConsumerResourceRequest = new ConsumerResourceRequest()
        };

        public ConsumerResourceRequestContainerBuilder WithTestValues()
        {
            _consumerResourceRequestContainer.ConsumerResourceRequest.ConsumerCountryCode = "SV";
            return this;
        }
    }
}
