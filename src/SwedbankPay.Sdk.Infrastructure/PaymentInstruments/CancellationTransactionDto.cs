using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments
{
    public class CancellationTransactionDto : List<TransactionDto>
    {
        internal ICancellationsListResponse Map() => throw new NotImplementedException();
    }
}