namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CardPaymentAbortPayment
    {
        public string Operation { get; } = "Abort";

        public CardPaymentAbortPayment(string abortReason)
        {
            AbortReason = abortReason;
        }

        public string AbortReason { get; set; }
    }
}