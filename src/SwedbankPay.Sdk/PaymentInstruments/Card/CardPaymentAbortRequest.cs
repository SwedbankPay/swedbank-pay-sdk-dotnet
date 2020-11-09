namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CardPaymentAbortRequest : ICardPaymentAbortRequest
    {
        public CardPaymentAbortRequest(string abortReason)
        {
            Payment = new CardPaymentAbortPayment(abortReason);
        }
        public CardPaymentAbortPayment Payment { get; }
    }
}