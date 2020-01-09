using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Transactions
{
    public class ReversalsListResponse : IdLink
    {
        public ReversalsListResponse(Uri id, List<TransactionResponse> reversalList)
        {
            Id = id;
            ReversalList = reversalList;
        }


        public List<TransactionResponse> ReversalList { get; }
    }
}