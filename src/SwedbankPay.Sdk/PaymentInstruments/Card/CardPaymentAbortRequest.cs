namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CardPaymentAbortRequest
    {
        public CardPaymentAbortRequest(string abortReason)
        {
            this.Payment = new CardPaymentAbortPayment(abortReason);
        }
        public CardPaymentAbortPayment Payment { get; }

        public class CardPaymentAbortPayment
        {
            public string Operation = "Abort";

            public CardPaymentAbortPayment(string abortReason)
            {
                AbortReason = abortReason;
            }

            public string AbortReason { get; set; }
        }
    }
}