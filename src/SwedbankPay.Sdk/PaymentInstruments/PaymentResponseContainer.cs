namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class PaymentResponseContainer<T>
    {
        public PaymentResponseContainer(
            IOperationList operations,
            T paymentResponse)
        {
            Operations = operations;
            Payment = paymentResponse;
        }


        public IOperationList Operations { get; }

        public T Payment { get; set; }
    }
}