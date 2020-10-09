namespace SwedbankPay.Sdk.Models.Requests.Consumers
{
    public class ViewConsumerShippingDetailsRequest
    {
        public string Operation { get; set; } = "view-consumer-shipping-details";

        public string ConsumerProfileRef { get; set; }
    }
}
