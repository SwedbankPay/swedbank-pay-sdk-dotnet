using System.Collections.Generic;

using Newtonsoft.Json;

namespace SwedbankPay.Sdk.Transactions
{
    public class ReversalsListContainer : IdLink
    {
        public ReversalsListContainer()
        {
            ReversalList = new List<TransactionContainerResponse>();
        }


        [JsonConstructor]
        public ReversalsListContainer(List<TransactionContainerResponse> reversalList)
        {
            ReversalList = reversalList;
        }


        public List<TransactionContainerResponse> ReversalList { get; }
    }
}