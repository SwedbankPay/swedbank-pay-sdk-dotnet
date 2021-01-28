namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPaymentAbortDto
    {
        public CardPaymentAbortDto(CardPaymentAbortPayment payment)
        {
            AbortReason = payment.AbortReason;
        }

        public string Operation { get; } = "Abort";

        public string AbortReason { get; }
    }
}