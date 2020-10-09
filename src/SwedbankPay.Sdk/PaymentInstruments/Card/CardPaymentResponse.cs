namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public class CardPaymentResponse : ICardPaymentResponse
    {
        public ICardPayment Payment { get; }
        public ICardPaymentOperations Operations { get; }
    }
}