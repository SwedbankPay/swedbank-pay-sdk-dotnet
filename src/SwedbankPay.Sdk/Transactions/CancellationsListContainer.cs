using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Transactions
{
    public class CancellationsListContainer : IdLink
    {
        public CancellationsListContainer(Uri id,  List<TransactionContainerResponse> cancellationList)
        {
            Id = id;
            CancellationList = cancellationList;
        }
        
        public List<TransactionContainerResponse> CancellationList { get; }
    }
}