namespace SwedbankPay.Sdk.Transactions
{
    internal class CaptureTransactionResponseContainer
    {
        public string Payment { get; set; }
        public TransactionContainer Capture { get; set; }
    }
}