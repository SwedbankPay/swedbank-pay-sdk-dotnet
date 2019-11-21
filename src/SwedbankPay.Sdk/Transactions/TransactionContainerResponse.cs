namespace SwedbankPay.Sdk.Transactions
{
    using Newtonsoft.Json;

    public class TransactionContainerResponse : IdLink
    {
        public TransactionResponse Transaction { get; }


        public TransactionContainerResponse()
        {
        }


        [JsonConstructor]
        public TransactionContainerResponse(TransactionResponse transaction)
        {
            Transaction = transaction;
        }
    }
}