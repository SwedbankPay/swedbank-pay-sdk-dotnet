namespace SwedbankPay.Sdk.Transactions
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class TransactionListContainer : IdLink
    {
        public List<TransactionResponse> TransactionList { get; }


        public TransactionListContainer()
        {
            TransactionList = new List<TransactionResponse>();
        }

        [JsonConstructor]
        public TransactionListContainer(List<TransactionResponse> transactionList)
        {
            TransactionList = transactionList;
        }
    }
}