
using Newtonsoft.Json;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderResponse
    { 
        public PaymentOrderResponse(OperationList operations, PaymentOrderResponseObject paymentorder)
        {
            Operations = operations;
            PaymentOrderResponseObject = paymentorder;
        }

        public OperationList Operations { get; }

        [JsonProperty("paymentorder")]
        public PaymentOrderResponseObject PaymentOrderResponseObject { get; }
    }
}