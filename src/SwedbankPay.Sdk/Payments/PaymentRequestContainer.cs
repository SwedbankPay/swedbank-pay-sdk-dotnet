using SwedbankPay.Sdk.Payments.Card;

namespace SwedbankPay.Sdk.Payments
{
    public class PaymentRequestContainer
    {
        public PaymentRequestContainer(PaymentRequest payment)
        {
            Payment = payment;
        }


        public PaymentRequest Payment { get; }
    }
}