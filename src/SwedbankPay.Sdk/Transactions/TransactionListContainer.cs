using System.Collections.Generic;

using Newtonsoft.Json;

namespace SwedbankPay.Sdk.Transactions
{
    public class TransactionListContainer : IdLink
    {
        public TransactionListContainer()
        {
            TransactionList = new List<TransactionResponse>();
        }


        [JsonConstructor]
        public TransactionListContainer(List<TransactionResponse> transactionList)
        {
            TransactionList = transactionList;
        }


        public List<TransactionResponse> TransactionList { get; }
    }
}