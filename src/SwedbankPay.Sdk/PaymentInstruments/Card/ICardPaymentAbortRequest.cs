namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public interface ICardPaymentAbortRequest
    {
        CardPaymentAbortPayment Payment { get; }
    }
}