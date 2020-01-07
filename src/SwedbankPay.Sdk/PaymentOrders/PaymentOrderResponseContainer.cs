using Newtonsoft.Json;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderResponseContainer
    { 
        public PaymentOrderResponseContainer(OperationList operations, 
                                             PaymentOrderResponse paymentOrderResponse)
        {
            Operations = operations;
            PaymentOrderResponse = paymentOrderResponse;
        }


        public OperationList Operations { get; }

        [JsonProperty("paymentorder")]
        public PaymentOrderResponse PaymentOrderResponse { get; }
    }
}