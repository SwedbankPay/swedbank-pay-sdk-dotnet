using SwedbankPay.Client.Models.Request;

namespace SwedbankPay.Client.Tests.TestBuilders
{
    public class ConsumerResourceRequestBuilder
    {
        private ConsumerResourceRequest _consumerResourceRequest = new ConsumerResourceRequest();
    

        public ConsumerResourceRequestBuilder WithTestValues()
        {
            _consumerResourceRequest.ConsumerCountryCode = "SE";
            return this;
        }

        public ConsumerResourceRequestBuilder WithEmtptyConsumerCountryCode()
        {
            _consumerResourceRequest.ConsumerCountryCode = "";
            return this;
        }

        public ConsumerResourceRequest Build()
        {
            return _consumerResourceRequest;
        }
    }
}
