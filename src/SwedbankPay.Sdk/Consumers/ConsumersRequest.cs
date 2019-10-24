namespace SwedbankPay.Sdk.Consumers
{
    using SwedbankPay.Sdk.PaymentOrders;

    public class ConsumersRequest
    {
        public string Operation { get; internal set; }
        public string Msisdn { get; set; }
        public string Email { get; set; }

        public string ConsumerCountryCode { get; set; }

        public NationalIdentifier NationalIdentifier { get; set; }
    }
}
