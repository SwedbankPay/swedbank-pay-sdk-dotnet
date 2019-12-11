using SwedbankPay.Sdk.Consumers;
using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.Tests.TestBuilders
{
    public class ConsumersRequestContainerBuilder
    {
        private CountryCode consumerCountryCode;

        private EmailAddress email;

        private Msisdn msisdn;

        private NationalIdentifier nationalIdentifier;
        private Operation operation;


        public ConsumersRequest Build()
        {
            return new ConsumersRequest(this.consumerCountryCode, this.operation);
        }


        public ConsumersRequestContainerBuilder WithTestValues()
        {
            this.consumerCountryCode = CountryCode.SE;
            this.operation = Operation.Initiate;
            return this;
        }
    }
}