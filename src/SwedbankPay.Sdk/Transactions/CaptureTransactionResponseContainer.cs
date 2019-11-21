namespace SwedbankPay.Sdk.Transactions
{
    using Newtonsoft.Json;

    internal class CaptureTransactionResponseContainer
    {
        public string Payment { get; }
        public TransactionContainer Capture { get; }


        public CaptureTransactionResponseContainer()
        {
        }


        [JsonConstructor]
        public CaptureTransactionResponseContainer(string payment, TransactionContainer capture)
        {
            Payment = payment;
            Capture = capture;
        }
    }
}