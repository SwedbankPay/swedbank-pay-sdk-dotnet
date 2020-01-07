using Newtonsoft.Json;

namespace SwedbankPay.Sdk.Payments
{
    public class PaymentResponseContainer
    {
        public PaymentResponseContainer(
            OperationList operations,
            PaymentResponse paymentResponse)
        {
            Operations = operations;
            PaymentResponse = paymentResponse;
        }


        public OperationList Operations { get; }

        [JsonProperty("payment")]
        public PaymentResponse PaymentResponse { get; }
    }
}