namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public interface ICardPaymentResponse
    {
        ICardPayment Payment { get; }
        ICardPaymentOperations Operations { get; }
    }
}