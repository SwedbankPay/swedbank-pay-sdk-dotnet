namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CardPaymentAbortRequest
    {
        public CardPaymentAbortRequest(string abortReason)
        {
            this.Payment = new CardPaymentAbortPayment(abortReason);
        }
        public CardPaymentAbortPayment Payment { get; }
    }
}