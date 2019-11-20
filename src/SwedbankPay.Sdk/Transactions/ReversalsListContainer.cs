namespace SwedbankPay.Sdk.Transactions
{
    using Newtonsoft.Json;

    using System.Collections.Generic;

    public class ReversalsListContainer : IdLink
    {
        public List<TransactionContainerResponse> ReversalList { get; }


        public ReversalsListContainer()
        {
            ReversalList = new List<TransactionContainerResponse>();
        }

        [JsonConstructor]
        public ReversalsListContainer(List<TransactionContainerResponse> reversalList)
        {
            ReversalList = reversalList;
        }
    }
}