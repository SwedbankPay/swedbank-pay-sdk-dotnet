namespace SwedbankPay.Sdk.Tests.TestBuilders
{
    using SwedbankPay.Sdk.Consumers;
    using SwedbankPay.Sdk.PaymentOrders;

    public class ConsumersRequestContainerBuilder
    {
        private Operation operation;

        private Msisdn msisdn;

        private EmailAddress email;

        private CountryCode consumerCountryCode;

        private NationalIdentifier nationalIdentifier;
        
        public ConsumersRequestContainerBuilder WithTestValues()
        {
            this.consumerCountryCode = CountryCode.SE;
            this.operation = Operation.Initiate; 
            return this;
        }

        public ConsumersRequest Build()
        {
            return new ConsumersRequest(this.consumerCountryCode, this.operation);
        }
    }
}
