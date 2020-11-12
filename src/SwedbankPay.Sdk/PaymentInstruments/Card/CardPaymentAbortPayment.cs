namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CardPaymentAbortPayment
    {
        public string Operation { get; } = "Abort";

        public CardPaymentAbortPayment(string abortReason)
        {
            AbortReason = abortReason;
        }

        /// <summary>
        /// The reason for why the payment is being aborted
        /// </summary>
        public string AbortReason { get; set; }
    }
}