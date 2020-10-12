using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments
{
    public class CaptureTransactionDto : List<TransactionDto>
    {
        internal ICapturesListResponse Map() => throw new NotImplementedException();
    }
}