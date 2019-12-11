using Newtonsoft.Json;

namespace SwedbankPay.Sdk.Transactions
{
    public class TransactionContainerResponse : IdLink
    {
        public TransactionContainerResponse()
        {
        }


        [JsonConstructor]
        public TransactionContainerResponse(TransactionResponse transaction)
        {
            Transaction = transaction;
        }


        public TransactionResponse Transaction { get; }
    }
}