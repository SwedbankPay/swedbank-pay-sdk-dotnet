namespace SwedbankPay.Sdk.Transactions
{
    internal class CaptureTransactionResponseContainer
    {
        public string Payment { get; protected set; }
        public TransactionContainer Capture { get; protected set; }
    }
}