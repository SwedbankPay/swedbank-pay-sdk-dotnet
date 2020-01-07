using Newtonsoft.Json;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderRequestContainer
    {
        public PaymentOrderRequestContainer(PaymentOrderRequest paymentOrderRequest)
        {
            PaymentOrderRequest = paymentOrderRequest;
        }

        [JsonProperty("paymentorder")]
        public PaymentOrderRequest PaymentOrderRequest { get; }
    }
}