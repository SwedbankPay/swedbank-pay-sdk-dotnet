namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CardPaymentResponse : ICardPaymentResponse
    {
        public ICardPayment Payment { get; }
        public ICardPaymentOperations Operations { get; }
    }
}