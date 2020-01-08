using Newtonsoft.Json;

namespace SwedbankPay.Sdk.Payments
{
    public class PaymentResponseContainer<T>
    {
        public PaymentResponseContainer(
            OperationList operations,
            T paymentResponse)
        {
            Operations = operations;
            PaymentResponse = paymentResponse;
        }


        public OperationList Operations { get; }

        [JsonProperty("payment")]
        public T PaymentResponse { get; }
    }
}