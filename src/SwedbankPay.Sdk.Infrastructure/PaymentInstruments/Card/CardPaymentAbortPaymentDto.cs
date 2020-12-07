namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPaymentAbortPaymentDto
    {
        public CardPaymentAbortPaymentDto(CardPaymentAbortPayment payment)
        {
            AbortReason = payment.AbortReason;
        }

        public string Operation { get; } = "Abort";

        public string AbortReason { get; }
    }
}