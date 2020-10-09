namespace SwedbankPay.Sdk.Payments
{
    public class PaymentResponseContainer<T>
    {
        public PaymentResponseContainer(
            OperationList operations,
            T paymentResponse)
        {
            Operations = operations;
            Payment = paymentResponse;
        }


        public OperationList Operations { get; }

        public T Payment { get; set; }
    }
}