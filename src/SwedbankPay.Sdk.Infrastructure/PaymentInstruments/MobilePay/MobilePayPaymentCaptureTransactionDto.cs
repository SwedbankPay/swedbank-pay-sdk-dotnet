namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    internal class MobilePayPaymentCaptureTransactionDto
    {
        public MobilePayPaymentCaptureTransactionDto(CaptureTransaction transaction)
        {
            Amount = transaction.Amount.InLowestMonetaryUnit;
            Description = transaction.Description;
            PayeeReference = transaction.PayeeReference;
            VatAmount = transaction.VatAmount.InLowestMonetaryUnit;
        }

        public long Amount { get; }

        public string Description { get; }

        public string PayeeReference { get; }

        public long VatAmount { get; }
    }
}