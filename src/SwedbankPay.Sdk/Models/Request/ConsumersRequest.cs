namespace SwedbankPay.Sdk.Models.Request
{
    public class ConsumersRequest
    {
        public string Operation { get; internal set; }
        public string Msisdn { get; set; }
        public string Email { get; set; }

        public string ConsumerCountryCode { get; set; }

        public NationalIdentifier NationalIdentifier { get; set; }
    }
}
