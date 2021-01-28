namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPaymentRecurResponseDto
    {
        public CardPaymentRecurResponseDetailsDto Payment { get; set; }

        public OperationListDto Operations { get; set; }
    }
}