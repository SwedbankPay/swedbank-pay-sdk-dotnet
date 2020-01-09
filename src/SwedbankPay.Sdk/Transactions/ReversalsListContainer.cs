using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Transactions
{
    public class ReversalsListContainer : IdLink
    {
        public ReversalsListContainer(Uri id, List<TransactionContainerResponse> reversalList)
        {
            Id = id;
            ReversalList = reversalList;
        }


        public List<TransactionContainerResponse> ReversalList { get; }
    }
}