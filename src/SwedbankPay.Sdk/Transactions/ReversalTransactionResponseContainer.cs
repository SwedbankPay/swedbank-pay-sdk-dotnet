namespace SwedbankPay.Sdk.Transactions
{
    using Newtonsoft.Json;

    internal class ReversalTransactionResponseContainer
    {
        public string Payment { get; }
        public TransactionContainer Reversal { get; }


        public ReversalTransactionResponseContainer()
        {
        }

        [JsonConstructor]
        public ReversalTransactionResponseContainer(string payment, TransactionContainer reversal)
        {
            Payment = payment;
            Reversal = reversal;
        }
    }
}