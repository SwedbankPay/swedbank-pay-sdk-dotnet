using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Transactions
{
    public class CancellationsListResponse : IdLink
    {
        public CancellationsListResponse(Uri id,  List<TransactionResponse> cancellationList)
        {
            Id = id;
            CancellationList = cancellationList;
        }
        
        public List<TransactionResponse> CancellationList { get; }
    }
}