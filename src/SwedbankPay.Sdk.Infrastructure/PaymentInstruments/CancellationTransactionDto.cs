using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class CancellationTransactionDto : List<TransactionDto>
    {
        internal ICancellationsListResponse Map() => throw new NotImplementedException();
    }
}