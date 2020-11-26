namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CardPaymentRecurResponseDto
    {
        public CardPaymentRecurResponseDetailsDto Payment { get; set; }

        public OperationListDto Operations { get; set; }
    }
}