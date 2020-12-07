namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPaymentCaptureRequestDto
    {
        public CardPaymentCaptureRequestDto(CardPaymentCaptureRequest payload)
        {
            Transaction = new CardPaymentCaptureTransactionDto(payload.Transaction);
        }

        public CardPaymentCaptureTransactionDto Transaction { get; }
    }
}